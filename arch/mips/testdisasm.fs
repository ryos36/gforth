here
$3FFF820 ,  \ 31 31 31 add,  
$10020 ,    \ 0 0 1 add,     
$200020 ,   \ 0 1 0 add,     
$820 ,	    \ 1 0 0 add,     
$210820 ,   \ 1 1 1 add,     
$23FFFFFF , \ 31 31 -1 addi, 
$20000001 , \ 0 0 1 addi,    
$20200000 , \ 0 1 0 addi,    
$20010000 , \ 1 0 0 addi,    
$20210001 , \ 1 1 1 addi,    
$27FFFFFF , \ 31 31 -1 addiu,
$24000001 , \ 0 0 1 addiu,   
$24200000 , \ 0 1 0 addiu,   
$24010000 , \ 1 0 0 addiu,   
$24210001 , \ 1 1 1 addiu,   
$3FFF821 ,  \ 31 31 31 addu, 
$10021 ,    \ 0 0 1 addu,    
$200021 ,   \ 0 1 0 addu,    
$821 ,	    \ 1 0 0 addu,    
$210821 ,   \ 1 1 1 addu,    
$3FFF824 ,  \ 31 31 31 and,  
$10024 ,    \ 0 0 1 and,     
$200024 ,   \ 0 1 0 and,     
$824 ,	    \ 1 0 0 and,     
$210824 ,   \ 1 1 1 and,     
$33FFFFFF , \ 31 31 $FFFF and
$30000001 , \ 0 0 $1 andi,   
$30200000 , \ 0 1 $0 andi,   
$30010000 , \ 1 0 $0 andi,   
$30210001 , \ 1 1 $1 andi,   
$4500FFFF , \ -1 bczf,       
$45000001 , \ 1 bczf,        
$4501FFFF , \ -1 bczt,       
$45010001 , \ 1 bczt,        
$13FFFFFF , \ 31 31 -1 beq,  
$10000001 , \ 0 0 1 beq,     
$10010000 , \ 0 1 0 beq,     
$10200000 , \ 1 0 0 beq,     
$10210001 , \ 1 1 1 beq,     
$7E1FFFF ,  \ 31 -1 bgez,    
$4010001 ,  \ 0 1 bgez,      
$4210000 ,  \ 1 0 bgez,      
$4210001 ,  \ 1 1 bgez,      
$7F1FFFF ,  \ 31 -1 bgezal,  
$4110001 ,  \ 0 1 bgezal,    
$4310000 ,  \ 1 0 bgezal,    
$4310001 ,  \ 1 1 bgezal,    
$1FE0FFFF , \ 31 -1 bgtz,    
$1C000001 , \ 0 1 bgtz,      
$1C200000 , \ 1 0 bgtz,      
$1C200001 , \ 1 1 bgtz,      
$1BE0FFFF , \ 31 -1 blez,    
$18000001 , \ 0 1 blez,      
$18200000 , \ 1 0 blez,      
$18200001 , \ 1 1 blez,      
$7E0FFFF ,  \ 31 -1 bltz,    
$4000001 ,  \ 0 1 bltz,      
$4200000 ,  \ 1 0 bltz,      
$4200001 ,  \ 1 1 bltz,      
$7F0FFFF ,  \ 31 -1 bltzal,  
$4100001 ,  \ 0 1 bltzal,    
$4300000 ,  \ 1 0 bltzal,    
$4300001 ,  \ 1 1 bltzal,    
$17FFFFFF , \ 31 31 -1 bne,  
$14000001 , \ 0 0 1 bne,     
$14010000 , \ 0 1 0 bne,     
$14200000 , \ 1 0 0 bne,     
$14210001 , \ 1 1 1 bne,     
$D ,	    \ break,         
$445FF800 , \ 31 31 1 cfcz,  
$44400800 , \ 0 1 1 cfcz,    
$44410000 , \ 1 0 1 cfcz,    
$44410800 , \ 1 1 1 cfcz,    
$44DFF800 , \ 31 31 1 ctcz,  
$44C00800 , \ 0 1 1 ctcz,    
$44C10000 , \ 1 0 1 ctcz,    
$44C10800 , \ 1 1 1 ctcz,    
$3FF001A ,  \ 31 31 div,     
$1001A ,    \ 0 1 div,       
$20001A ,   \ 1 0 div,       
$21001A ,   \ 1 1 div,       
$3FF001B ,  \ 31 31 divu,    
$1001B ,    \ 0 1 divu,      
$20001B ,   \ 1 0 divu,      
$21001B ,   \ 1 1 divu,      
$BFFFFFF ,  \ $43FFFFFF j,   
$8000001 ,  \ $40000001 j,   
$FFFFFFF ,  \ $43FFFFFF jal, 
$C000001 ,  \ $40000001 jal, 
$3E0F809 ,  \ 31 31 jalr,    
$200009 ,   \ 0 1 jalr,      
$809 ,	    \ 1 0 jalr,      
$200809 ,   \ 1 1 jalr,      
$3E00008 ,  \ 31 jr,         
$200008 ,   \ 1 jr,          
$83FFFFFF , \ 31 -1 31 lb,   
$80200000 , \ 0 0 1 lb,      
$80000001 , \ 0 1 0 lb,      
$80010000 , \ 1 0 0 lb,      
$80210001 , \ 1 1 1 lb,      
$93FFFFFF , \ 31 -1 31 lbu,  
$90200000 , \ 0 0 1 lbu,     
$90000001 , \ 0 1 0 lbu,     
$90010000 , \ 1 0 0 lbu,     
$90210001 , \ 1 1 1 lbu,     
$87FFFFFF , \ 31 -1 31 lh,   
$84200000 , \ 0 0 1 lh,      
$84000001 , \ 0 1 0 lh,      
$84010000 , \ 1 0 0 lh,      
$84210001 , \ 1 1 1 lh,      
$97FFFFFF , \ 31 -1 31 lhu,  
$94200000 , \ 0 0 1 lhu,     
$94000001 , \ 0 1 0 lhu,     
$94010000 , \ 1 0 0 lhu,     
$94210001 , \ 1 1 1 lhu,     
$3C1FFFFF , \ 31 $FFFF lui,  
$3C000001 , \ 0 $1 lui,      
$3C010000 , \ 1 $0 lui,      
$3C010001 , \ 1 $1 lui,      
$8FFFFFFF , \ 31 -1 31 lw,   
$8C200000 , \ 0 0 1 lw,      
$8C000001 , \ 0 1 0 lw,      
$8C010000 , \ 1 0 0 lw,      
$8C210001 , \ 1 1 1 lw,      
$C7FFFFFF , \ 31 -1 31 lwc1, 
$C4200000 , \ 0 0 1 lwc1,    
$C4000001 , \ 0 1 0 lwc1,    
$C4010000 , \ 1 0 0 lwc1,    
$C4210001 , \ 1 1 1 lwc1,    
$8BFFFFFF , \ 31 -1 31 lwl,  
$88200000 , \ 0 0 1 lwl,     
$88000001 , \ 0 1 0 lwl,     
$88010000 , \ 1 0 0 lwl,     
$88210001 , \ 1 1 1 lwl,     
$9BFFFFFF , \ 31 -1 31 lwr,  
$98200000 , \ 0 0 1 lwr,     
$98000001 , \ 0 1 0 lwr,     
$98010000 , \ 1 0 0 lwr,     
$98210001 , \ 1 1 1 lwr,     
$441FF800 , \ 31 31 1 mfcz,  
$44000800 , \ 0 1 1 mfcz,    
$44010000 , \ 1 0 1 mfcz,    
$44010800 , \ 1 1 1 mfcz,    
$F810 ,	    \ 31 mfhi,       
$810 ,	    \ 1 mfhi,        
$F812 ,	    \ 31 mflo,       
$812 ,	    \ 1 mflo,        
$449FF800 , \ 31 31 1 mtcz,  
$44800800 , \ 0 1 1 mtcz,    
$44810000 , \ 1 0 1 mtcz,    
$44810800 , \ 1 1 1 mtcz,    
$3E00011 ,  \ 31 mthi,       
$200011 ,   \ 1 mthi,        
$3E00013 ,  \ 31 mtlo,       
$200013 ,   \ 1 mtlo,        
$3FF0018 ,  \ 31 31 mult,    
$10018 ,    \ 0 1 mult,      
$200018 ,   \ 1 0 mult,      
$210018 ,   \ 1 1 mult,      
$3FF0019 ,  \ 31 31 multu,   
$10019 ,    \ 0 1 multu,     
$200019 ,   \ 1 0 multu,     
$210019 ,   \ 1 1 multu,     
$3FFF827 ,  \ 31 31 31 nor,  
$10027 ,    \ 0 0 1 nor,     
$200027 ,   \ 0 1 0 nor,     
$827 ,	    \ 1 0 0 nor,     
$210827 ,   \ 1 1 1 nor,     
$3FFF825 ,  \ 31 31 31 or,   
$10025 ,    \ 0 0 1 or,      
$200025 ,   \ 0 1 0 or,      
$825 ,	    \ 1 0 0 or,      
$210825 ,   \ 1 1 1 or,      
$37FFFFFF , \ 31 31 $FFFF ori
$34000001 , \ 0 0 $1 ori,    
$34200000 , \ 0 1 $0 ori,    
$34010000 , \ 1 0 $0 ori,    
$34210001 , \ 1 1 $1 ori,    
$A3FFFFFF , \ 31 -1 31 sb,   
$A0200000 , \ 0 0 1 sb,      
$A0000001 , \ 0 1 0 sb,      
$A0010000 , \ 1 0 0 sb,      
$A0210001 , \ 1 1 1 sb,      
$A7FFFFFF , \ 31 -1 31 sh,   
$A4200000 , \ 0 0 1 sh,      
$A4000001 , \ 0 1 0 sh,      
$A4010000 , \ 1 0 0 sh,      
$A4210001 , \ 1 1 1 sh,      
$3FFF82A ,  \ 31 31 31 slt,  
$1002A ,    \ 0 0 1 slt,     
$20002A ,   \ 0 1 0 slt,     
$82A ,	    \ 1 0 0 slt,     
$21082A ,   \ 1 1 1 slt,     
$2BFFFFFF , \ 31 31 -1 slti, 
$28000001 , \ 0 0 1 slti,    
$28200000 , \ 0 1 0 slti,    
$28010000 , \ 1 0 0 slti,    
$28210001 , \ 1 1 1 slti,    
$2FFFFFFF , \ 31 31 -1 sltiu,
$2C000001 , \ 0 0 1 sltiu,   
$2C200000 , \ 0 1 0 sltiu,   
$2C010000 , \ 1 0 0 sltiu,   
$2C210001 , \ 1 1 1 sltiu,   
$3FFF82B ,  \ 31 31 31 sltu, 
$1002B ,    \ 0 0 1 sltu,    
$20002B ,   \ 0 1 0 sltu,    
$82B ,	    \ 1 0 0 sltu,    
$21082B ,   \ 1 1 1 sltu,    
$3FFF822 ,  \ 31 31 31 sub,  
$10022 ,    \ 0 0 1 sub,     
$200022 ,   \ 0 1 0 sub,     
$822 ,	    \ 1 0 0 sub,     
$210822 ,   \ 1 1 1 sub,     
$3FFF823 ,  \ 31 31 31 subu, 
$10023 ,    \ 0 0 1 subu,    
$200023 ,   \ 0 1 0 subu,    
$823 ,	    \ 1 0 0 subu,    
$210823 ,   \ 1 1 1 subu,    
$AFFFFFFF , \ 31 -1 31 sw,   
$AC200000 , \ 0 0 1 sw,      
$AC000001 , \ 0 1 0 sw,      
$AC010000 , \ 1 0 0 sw,      
$AC210001 , \ 1 1 1 sw,      
$E7FFFFFF , \ 31 -1 31 swc1, 
$E4200000 , \ 0 0 1 swc1,    
$E4000001 , \ 0 1 0 swc1,    
$E4010000 , \ 1 0 0 swc1,    
$E4210001 , \ 1 1 1 swc1,    
$ABFFFFFF , \ 31 -1 31 swl,  
$A8200000 , \ 0 0 1 swl,     
$A8000001 , \ 0 1 0 swl,     
$A8010000 , \ 1 0 0 swl,     
$A8210001 , \ 1 1 1 swl,     
$BBFFFFFF , \ 31 -1 31 swr,  
$B8200000 , \ 0 0 1 swr,     
$B8000001 , \ 0 1 0 swr,     
$B8010000 , \ 1 0 0 swr,     
$B8210001 , \ 1 1 1 swr,     
$C ,	    \ syscall,       
$42000008 , \ tlbl,          
$42000001 , \ tlbr,          
$42000002 , \ tlbwi,         
$42000006 , \ tlbwr,         
$3FFF826 ,  \ 31 31 31 xor,  
$10026 ,    \ 0 0 1 xor,     
$200026 ,   \ 0 1 0 xor,     
$826 ,	    \ 1 0 0 xor,     
$210826 ,   \ 1 1 1 xor,     
$3BFFFFFF , \ 31 31 $FFFF xor
$38000001 , \ 0 0 $1 xori,   
$38200000 , \ 0 1 $0 xori,   
$38010000 , \ 1 0 $0 xori,   
$38210001 , \ 1 1 $1 xori,   
$3E0F821 ,  \ 31 31 0 addu,  
$200021 ,   \ 0 1 0 addu,    
$821 ,	    \ 1 0 0 addu,    
$200821 ,   \ 1 1 0 addu,    
$7E10002 ,  \ 31 2 bgez,     
$3E0F821 ,  \ 31 31 0 addu,  
$1FF822 ,   \ 31 0 31 sub,   
$4210002 ,  \ 1 2 bgez,      
$200021 ,   \ 0 1 0 addu,    
$10022 ,    \ 0 0 1 sub,     
$4010002 ,  \ 0 2 bgez,      
$821 ,	    \ 1 0 0 addu,    
$822 ,	    \ 1 0 0 sub,     
$4210002 ,  \ 1 2 bgez,      
$200821 ,   \ 1 1 0 addu,    
$10822 ,    \ 1 0 1 sub,     
$1FF822 ,   \ 31 0 31 sub,   
$10022 ,    \ 0 0 1 sub,     
$822 ,	    \ 1 0 0 sub,     
$10822 ,    \ 1 0 1 sub,     
$1FF823 ,   \ 31 0 31 subu,  
$10023 ,    \ 0 0 1 subu,    
$823 ,	    \ 1 0 0 subu,    
$10823 ,    \ 1 0 1 subu,    
$3E0F827 ,  \ 31 31 0 nor,   
$200027 ,   \ 0 1 0 nor,     
$827 ,	    \ 1 0 0 nor,     
$200827 ,   \ 1 1 0 nor,     
$3FF082A ,  \ 1 31 31 slt,   
$1420FFFF , \ 1 0 -1 bne,    
$82A ,	    \ 1 0 0 slt,     
$14200001 , \ 1 0 1 bne,     
$1082A ,    \ 1 0 1 slt,     
$14200000 , \ 1 0 0 bne,     
$20082A ,   \ 1 1 0 slt,     
$14200000 , \ 1 0 0 bne,     
$21082A ,   \ 1 1 1 slt,     
$14200001 , \ 1 0 1 bne,     
$3FF082A ,  \ 1 31 31 slt,   
$1020FFFF , \ 1 0 -1 beq,    
$82A ,	    \ 1 0 0 slt,     
$10200001 , \ 1 0 1 beq,     
$20082A ,   \ 1 1 0 slt,     
$10200000 , \ 1 0 0 beq,     
$1082A ,    \ 1 0 1 slt,     
$10200000 , \ 1 0 0 beq,     
$21082A ,   \ 1 1 1 slt,     
$10200001 , \ 1 0 1 beq,     
$3FF082A ,  \ 1 31 31 slt,   
$1420FFFF , \ 1 0 -1 bne,    
$82A ,	    \ 1 0 0 slt,     
$14200001 , \ 1 0 1 bne,     
$20082A ,   \ 1 1 0 slt,     
$14200000 , \ 1 0 0 bne,     
$1082A ,    \ 1 0 1 slt,     
$14200000 , \ 1 0 0 bne,     
$21082A ,   \ 1 1 1 slt,     
$14200001 , \ 1 0 1 bne,     
$3FF082B ,  \ 1 31 31 sltu,  
$1020FFFF , \ 1 0 -1 beq,    
$82B ,	    \ 1 0 0 sltu,    
$10200001 , \ 1 0 1 beq,     
$1082B ,    \ 1 0 1 sltu,    
$10200000 , \ 1 0 0 beq,     
$20082B ,   \ 1 1 0 sltu,    
$10200000 , \ 1 0 0 beq,     
$21082B ,   \ 1 1 1 sltu,    
$10200001 , \ 1 0 1 beq,     
$3FF082B ,  \ 1 31 31 sltu,  
$1420FFFF , \ 1 0 -1 bne,    
$82B ,	    \ 1 0 0 sltu,    
$14200001 , \ 1 0 1 bne,     
$1082B ,    \ 1 0 1 sltu,    
$14200000 , \ 1 0 0 bne,     
$20082B ,   \ 1 1 0 sltu,    
$14200000 , \ 1 0 0 bne,     
$21082B ,   \ 1 1 1 sltu,    
$14200001 , \ 1 0 1 bne,     
$3FF082B ,  \ 1 31 31 sltu,  
$1020FFFF , \ 1 0 -1 beq,    
$82B ,	    \ 1 0 0 sltu,    
$10200001 , \ 1 0 1 beq,     
$20082B ,   \ 1 1 0 sltu,    
$10200000 , \ 1 0 0 beq,     
$1082B ,    \ 1 0 1 sltu,    
$10200000 , \ 1 0 0 beq,     
$21082B ,   \ 1 1 1 sltu,    
$10200001 , \ 1 0 1 beq,     
$3FF082B ,  \ 1 31 31 sltu,  
$1420FFFF , \ 1 0 -1 bne,    
$82B ,	    \ 1 0 0 sltu,    
$14200001 , \ 1 0 1 bne,     
$20082B ,   \ 1 1 0 sltu,    
$14200000 , \ 1 0 0 bne,     
$1082B ,    \ 1 0 1 sltu,    
$14200000 , \ 1 0 0 bne,     
$21082B ,   \ 1 1 1 sltu,    
$14200001 , \ 1 0 1 bne,     
$3FF082B ,  \ 1 31 31 sltu,  
$1020FFFF , \ 1 0 -1 beq,    
$82B ,	    \ 1 0 0 sltu,    
$10200001 , \ 1 0 1 beq,     
$1082B ,    \ 1 0 1 sltu,    
$10200000 , \ 1 0 0 beq,     
$20082B ,   \ 1 1 0 sltu,    
$10200000 , \ 1 0 0 beq,     
$21082B ,   \ 1 1 1 sltu,    
$10200001 , \ 1 0 1 beq,     
here over - disasm-dump

