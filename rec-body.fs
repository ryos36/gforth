\ <body[+offset]> recognizer
\ <foo> puts the body of foo on the stack like ' foo >body does

\ Author: Bernd Paysan
\ Copyright (C) 2019,2020,2021 Free Software Foundation, Inc.

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

[IFUNDEF] ?rec-nt
    : ?rec-nt ( addr u -- xt true / something 0 )
	sp@ >in @ 2>r
	forth-recognize ['] translate-nt = dup
	if  2r> 2over  else  2r> #0.  then  2>r >in ! sp!
	2drop 2r> ;
[THEN]

: rec-body ( addr u -- xt translate-tick | translate-null ) \ gforth-experimental
    \G words bracketed with @code{'<'} @code{'>'} return their body.
    \G Example: @code{<dup>} gives the body of dup
    over c@ '<' <> >r  2dup + 1- c@ '>' <> r> or
    if 2drop ['] notfound exit then
    1 /string 1- '+' $split 2>r ?rec-nt
    0= if  drop 2rdrop ['] notfound exit then
    name>int >body
    2r> dup 0= if  2drop ['] translate-num  exit  then
    case  rec-num
    ['] translate-dnum of  drop + ['] translate-num   endof
    ['] translate-num  of       + ['] translate-num   endof
    swap  endcase ;

' rec-body forth-recognizer >back
