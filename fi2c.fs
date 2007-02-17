\ Convert image to C include file

\ Copyright (C) 1998,1999,2002,2003 Free Software Foundation, Inc.

\ This file is part of Gforth.

\ Gforth is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public License
\ as published by the Free Software Foundation; either version 2
\ of the License, or (at your option) any later version.

\ This program is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
\ GNU General Public License for more details.

\ You should have received a copy of the GNU General Public License
\ along with this program; if not, write to the Free Software
\ Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111, USA.

require string.fs

0 Value image
0 Value bitmap

Create magicbuf 8 allot

Create groups 32 0 [DO] 512 cells allocate throw dup 512 cells erase , [LOOP]

: prefix? ( string u1 prefix u2 -- flag )
    tuck 2>r umin 2r> str= ;

: read-groups ( addr u -- )
    r/o open-file throw >r  0 0
    BEGIN  pad $100 r@ read-line throw  WHILE
	    pad swap 2dup s" GROUP(" prefix?
	    IF  2drop drop 1+ 0  ELSE
		2dup s" INST_ADDR(" prefix?
		IF  &10 /string 2dup ') scan nip -
		    2over cells swap cells groups + @ + $!
		    1+
		ELSE  2drop  THEN  THEN
    REPEAT
    2drop r> close-file throw ;
s" prim_lab.i" read-groups

Variable bswap?
Variable endian
Variable tchars
Variable tcell
Variable au

: t@ ( addr -- x )
    endian @ IF
	0 swap tcell @ bounds ?DO
	    8 lshift I c@ or
	LOOP
    ELSE
	0 swap tcell @ bounds ?DO
	    8 rshift I c@ 8 tcell @ 1- * lshift or
	LOOP
    THEN
    dup 1 8 tcell @ * 1- lshift and negate or ;

1 cells 4 = [IF]
: bswap ( n -- n' )  bswap? @ 0= ?EXIT  0
    over 24 rshift $FF       and or
    over  8 rshift $FF00     and or
    over  8 lshift $FF0000   and or
    over 24 lshift $FF000000 and or nip ;
[THEN]

1 cells 8 = [IF]
: bswap ( n -- n' )  bswap? @ 0= ?EXIT  0
    over 56 rshift $FF               and or
    over 40 rshift $FF00             and or
    over 24 rshift $FF0000           and or
    over  8 rshift $FF000000         and or
    over  8 lshift $FF00000000       and or
    over 24 lshift $FF0000000000     and or
    over 40 lshift $FF000000000000   and or
    over 56 lshift $FF00000000000000 and or
    nip ;
[THEN]

: search-magic ( fd -- )  >r
    BEGIN  magicbuf 8 r@ read-file throw  8 =  WHILE
	magicbuf s" Gforth3" tuck str=  UNTIL
    ELSE  true abort" No magic found"  THEN
    1 magicbuf 7 + c@ 5 rshift 3 and lshift tchars !
    1 magicbuf 7 + c@ 1 rshift 3 and lshift tcell !
    1 magicbuf 7 + c@ 3 rshift 3 and lshift au !
    magicbuf 7 + c@ 1 and 0= dup endian !
    [ pad off 1 pad ! pad c@ 1 = ] Literal = bswap? !
    ." /* Image with " tcell @ . ." bytes cell, " tchars @ . ." bytes per char and " au @ . ." bytes per address unit */" cr
    rdrop ;

Create image-header  4 cells allot
Variable image-cells
Variable bitmap-chars

: read-header ( fd -- )
    image-header 4 tcell @ * rot read-file throw drop
    image-header 2 tcell @ * + t@ tchars @ * tcell @ / au @ /
    dup image-cells ! 1- 8 / tchars @ / 1+ bitmap-chars !
    image-cells @ tcell @ * allocate throw to image
    bitmap-chars @ allocate throw to bitmap ;

: read-dictionary ( fd -- )  >r
    image image-cells @ tcell @ * r> read-file throw drop ;

: read-bitmap ( fd -- )  >r
    bitmap bitmap-chars @ tchars @ * r> read-file throw drop ;

: .08x ( n -- ) 0 <# tcell  @ 0 ?DO # # LOOP 'x hold '0 hold #> type ;
: .02x ( n -- ) 0 <# tchars @ 0 ?DO # # LOOP 'x hold '0 hold #> type ;

: bit@ ( addr n -- flag )
    dup 7 and $80 swap rshift >r 3 rshift + c@ r> and
    0<> ;

: .image ( -- )
    image-cells @ 0 ?DO
	I 1 + I' min I ?DO  space image I tcell @ * + t@
	    bitmap I bit@ IF
		dup 0< IF
		    negate dup $3E00 and 9 rshift swap $1FF and
		    over cells groups + @ over $1FF and cells +
		    dup @ 0= IF  drop
			2dup 0 8 d= IF  2drop s" doesjump"
			ELSE
			    <# '] hold 0 #S 2drop '[ hold '] hold
			    0 #S '[ hold #>
			THEN
		    ELSE
			>r 2drop r> $@
		    THEN
		    ." &&" type
		ELSE
		    ." image+" tcell @ / .08x
		THEN
	    ELSE
		.08x
	    THEN  ." ,"
	LOOP cr
    1 +LOOP ;

: .reloc ( -- )
    bitmap-chars @ tchars @ * 0 ?DO
	I $10 + I' min I ?DO  space
	    0 I tchars @ bounds ?DO  8 lshift bitmap I + c@ +  LOOP
	    .02x ." ," tchars @ +LOOP cr
	$10 +LOOP ;

: read-image ( addr u -- )
    r/o bin open-file throw >r
    r@ search-magic
    r@ file-position throw r@ read-header r@ reposition-file throw
    r@ read-dictionary r@ read-bitmap r> close-file throw ;

: .imagesize ( -- )
    image-header 3 tcell @ * + t@ tchars @ * tcell @ / au @ / .08x ;

: .relocsize ( -- )
    bitmap-chars @ .08x ;

: fi2c ( addr u -- )  base @ >r hex
    read-image
    ." #include " '" emit ." forth.h" '" emit cr
    ." void* image[" .imagesize ." ] = {" cr .image ." };" cr
    ." const char reloc_bits[" .relocsize ." ] = {" cr .reloc ." };" cr
    r> base ! ;

