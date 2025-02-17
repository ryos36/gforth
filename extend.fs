\ EXTEND.FS    CORE-EXT Word not fully tested!         12may93jaw

\ Authors: Anton Ertl, Bernd Paysan, Neal Crook, Jens Wilke
\ Copyright (C) 1995,1998,2000,2003,2005,2007,2009,2010,2011,2013,2014,2016,2017,2018,2019,2020,2021 Free Software Foundation, Inc.

\ This file is part of Gforth.

\ Gforth is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public License
\ as published by the Free Software Foundation, either version 3
\ of the License, or (at your option) any later version.

\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program. If not, see http://www.gnu.org/licenses/.


\ May be cross-compiled

decimal

\ .(                                                    12may93jaw

: .(   ( compilation&interpretation "ccc<paren>" -- ) \ core-ext dot-paren
  \G Compilation and interpretation semantics: Parse a string @i{ccc}
  \G delimited by a @code{)} (right parenthesis). Display the
  \G string. This is often used to display progress information during
  \G compilation; see examples below.
  ')' parse type ; immediate

\ VALUE 2>R 2R> 2R@                                     17may93jaw

\ !! 2value

[ifundef] 2literal
: 2Literal ( compilation w1 w2 -- ; run-time  -- w1 w2 ) \ double two-literal
    \G Compile appropriate code such that, at run-time, cell pair @i{w1, w2} are
    \G placed on the stack. Interpretation semantics are undefined.
    swap postpone Literal  postpone Literal ; immediate restrict
[then]

' drop alias d>s ( d -- n ) \ double		d_to_s

: m*/ ( d1 n2 u3 -- dquot ) \ double m-star-slash
    \G dquot=(d1*n2)/u3, with the intermediate result being triple-precision.
    \G In ANS Forth u3 can only be a positive signed number.
    >r s>d >r abs -rot
    s>d r> xor r> swap >r >r dabs rot tuck um* 2swap um*
    swap >r 0 d+ r> -rot r@ um/mod -rot r> um/mod
    [ 1 -3 mod 0< ] [if]
        -rot r> IF IF 1. d+ THEN dnegate ELSE drop THEN
    [else]
        nip swap r> IF dnegate THEN
    [then] ;

\ C"                                                    17may93jaw

: C" ( compilation "ccc<quote>" -- ; run-time  -- c-addr ) \ core-ext c-quote
    \G Compilation: parse a string @i{ccc} delimited by a @code{"}
    \G (double quote). At run-time, return @i{c-addr} which
    \G specifies the counted string @i{ccc}.  Interpretation
    \G semantics are undefined.
    '"' parse dup 255 u> -18 and throw postpone CLiteral ; immediate restrict

\ [COMPILE]                                             17may93jaw

: [compile] ( compilation "name" -- ; run-time ? -- ? ) \ core-ext bracket-compile
    comp' drop
    dup [ comp' exit drop ] literal = if
	execute \ EXIT has default compilation semantics, perform them
    else
	compile,
    then ; immediate

\ CONVERT                                               17may93jaw

: convert ( ud1 c-addr1 -- ud2 c-addr2 ) \ core-ext-obsolescent
    \G Obsolescent: superseded by @code{>number}.
    char+ true >number drop ;

\ ERASE                                                 17may93jaw

: blank ( c-addr u -- ) \ string
    \G Store the space character into @i{u} chars starting at @i{c-addr}.
    bl fill ;

\ SEARCH                                                02sep94py

: search ( c-addr1 u1 c-addr2 u2 -- c-addr3 u3 flag ) \ string
    \G Search the string specified by @i{c-addr1, u1} for the string
    \G specified by @i{c-addr2, u2}. If @i{flag} is true: match was found
    \G at @i{c-addr3} with @i{u3} characters remaining. If @i{flag} is false:
    \G no match was found; @i{c-addr3, u3} are equal to @i{c-addr1, u1}.
    \ not very efficient; but if we want efficiency, we'll do it as primitive
    2>r 2dup
    begin
	dup r@ >=
    while
	2dup 2r@ string-prefix? if
	    2swap 2drop 2r> 2drop true exit
	endif
	1 /string
    repeat
    2drop 2r> 2drop false ;

: capsstring-prefix? ( c-addr1 u1 c-addr2 u2 -- f ) \ gforth
    \G Is @var{c-addr2 u2} a case-oblivious prefix of @var{c-addr1 u1}?
    tuck 2>r umin 2r> capscompare 0= ;

: capssearch ( c-addr1 u1 c-addr2 u2 -- c-addr3 u3 flag ) \ gforth
    \G Like \code{search}, but case-insensitive for ASCII characters:
    \G Search for c-addr2 u2 in c-addr1 u1; flag is true if found.
    2>r 2dup begin ( c-addr1 u1 c-addr4 u4 )
        dup r@ u>= while
	    2dup 2r@ capsstring-prefix? if
		2swap 2drop 2r> 2drop true exit then
	    1 /string
    repeat
    2drop 2r> 2drop false ;

\ SOURCE-ID SAVE-INPUT RESTORE-INPUT                    11jun93jaw

[IFUNDEF] source-id
: source-id ( -- 0 | -1 | fileid ) \ core-ext,file source-i-d
    \G Return 0 (the input source is the user input device), -1 (the
    \G input source is a string being processed by @code{evaluate}) or
    \G a @i{fileid} (the input source is the file specified by
    \G @i{fileid}).
    loadfile @ dup 0= IF  drop sourceline# 0 min  THEN ;

: save-input ( -- xn .. x1 n ) \ core-ext
    \G The @i{n} entries @i{xn - x1} describe the current state of the
    \G input source specification, in some platform-dependent way that can
    \G be used by @code{restore-input}.
    >in @
    loadfile @
    if
	loadfile @ file-position throw
	[IFDEF] #fill-bytes #fill-bytes @ [ELSE] #tib @ 1+ [THEN] 0 d-
    else
	blk @
	linestart @
    then
    sourceline#
    >tib @
    source-id
    6 ;

: restore-input ( xn .. x1 n -- flag ) \ core-ext
    \G Attempt to restore the input source specification to the state
    \G described by the @i{n} entries @i{xn - x1}. @i{flag} is
    \G true if the restore fails.  In Gforth it fails pretty often
    \G (and sometimes with a @code{throw}).
    6 <> -12 and throw
    source-id <> -12 and throw
    >tib !
    >r ( line# )
    loadfile @ 0<>
    if
	loadfile @ reposition-file throw
	refill 0= -36 and throw \ should never throw
    else
	linestart !
	blk !
	sourceline# r@ <> blk @ 0= and loadfile @ 0= and
	if
	    drop rdrop true EXIT
	then
    then
    r> loadline !
    >in !
    false ;
[THEN]
\ This things we don't need, but for being complete... jaw

\ EXPECT SPAN                                           17may93jaw

variable span ( -- c-addr ) \ core-ext-obsolescent
\G @code{Variable} -- @i{c-addr} is the address of a cell that stores the
\G length of the last string received by @code{expect}. OBSOLESCENT.

: expect ( c-addr +n -- ) \ core-ext-obsolescent
    \G Receive a string of at most @i{+n} characters, and store it
    \G in memory starting at @i{c-addr}. The string is
    \G displayed. Input terminates when the <return> key is pressed or
    \G @i{+n} characters have been received. The normal Gforth line
    \G editing capabilites are available. The length of the string is
    \G stored in @code{span}; it does not include the <return>
    \G character. OBSOLESCENT: superceeded by @code{accept}.
    everyline
    0 rot over
    BEGIN ( maxlen span c-addr pos1 )
	xkey decode ( maxlen span c-addr pos2 flag )
	>r 2over = r> or
    UNTIL
    third swap /string type
    nip span ! ;
