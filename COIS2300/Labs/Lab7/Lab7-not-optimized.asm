; Listing generated by Microsoft (R) Optimizing Compiler Version 19.15.26729.0 

	TITLE	C:\Users\Alisher\Desktop\University\2018-2019 Winter\COIS2300\Labs\Lab 7\Lab7\Lab7\Lab7.cpp
	.686P
	.XMM
	include listing.inc
	.model	flat

INCLUDELIB MSVCRTD
INCLUDELIB OLDNAMES

msvcjmc	SEGMENT
__AC32701A_pch.h DB 01H
__2ABF52E4_lab7.pch DB 01H
__86A46991_xstddef DB 01H
__71BBFE83_utility DB 01H
__80ECD3C5_streambuf DB 01H
__A3D3B529_ostream DB 01H
__C0038013_istream DB 01H
__6FFD1BDC_xstring DB 01H
__0D6D97F6_lab7.cpp DB 01H
__AA1182C5_ios DB 01H
__2E4409FA_xlocnum DB 01H
__D7FEF932_xiosbase DB 01H
__830E8A2A_system_error DB 01H
__3C53980A_xcall_once.h DB 01H
__B0C36FED_xlocale DB 01H
__CE98FDDF_xfacet DB 01H
__E2DDAAD0_memory DB 01H
__EE1B8E21_xlocinfo DB 01H
__7C512EE2_ctype.h DB 01H
__C57511A8_vcruntime_typeinfo.h DB 01H
__824C6B79_stdexcept DB 01H
__A040127E_xatomic0.h DB 01H
__501E5FA1_xmemory0 DB 01H
__814D9EF0_xutility DB 01H
__929A73D8_iosfwd DB 01H
__5E73A65E_limits DB 01H
__5D5F9F21_wchar.h DB 01H
__33831CCF_stat.h DB 01H
__90701A18_corecrt_wtime.h DB 01H
__BE076D93_corecrt_wio.h DB 01H
__FEB88A67_corecrt_wconio.h DB 01H
__0B025124_exception DB 01H
__8AB4B352_vcruntime_exception.h DB 01H
__6AAA6594_malloc.h DB 01H
__B1799763_type_traits DB 01H
__78F4D6C6_string.h DB 01H
__9CE3A74D_corecrt_wstring.h DB 01H
__9F081559_corecrt_memory.h DB 01H
__07523DAF_corecrt_memcpy_s.h DB 01H
__A3797CDC_stdio.h DB 01H
__BAC7FC50_corecrt_wstdio.h DB 01H
__320E01E0_corecrt_stdio_config.h DB 01H
__457D4847_xtgmath.h DB 01H
__421A99BA_cmath DB 01H
__46B67B08_cstdlib DB 01H
__EDC08FAA_corecrt_math.h DB 01H
__FE874262_stdlib.h DB 01H
__545EB0C3_vcruntime_new.h DB 01H
msvcjmc	ENDS
PUBLIC	?__empty_global_delete@@YAXPAX@Z		; __empty_global_delete
PUBLIC	?__empty_global_delete@@YAXPAXI@Z		; __empty_global_delete
PUBLIC	_main
PUBLIC	__real@33d6bf95
PUBLIC	__real@3f800000
PUBLIC	__real@3ff0000000000000
PUBLIC	__real@416312d000000000
EXTRN	__imp_?precision@ios_base@std@@QAE_J_J@Z:PROC
EXTRN	__imp_??6?$basic_ostream@DU?$char_traits@D@std@@@std@@QAEAAV01@M@Z:PROC
EXTRN	__imp_?get@?$basic_istream@DU?$char_traits@D@std@@@std@@QAEHXZ:PROC
EXTRN	@__CheckForDebuggerJustMyCode@4:PROC
EXTRN	__RTC_CheckEsp:PROC
EXTRN	__RTC_InitBase:PROC
EXTRN	__RTC_Shutdown:PROC
EXTRN	__imp_?cin@std@@3V?$basic_istream@DU?$char_traits@D@std@@@1@A:BYTE
EXTRN	__imp_?cout@std@@3V?$basic_ostream@DU?$char_traits@D@std@@@1@A:BYTE
EXTRN	__fltused:DWORD
;	COMDAT __real@416312d000000000
CONST	SEGMENT
__real@416312d000000000 DQ 0416312d000000000r	; 1e+07
CONST	ENDS
;	COMDAT __real@3ff0000000000000
CONST	SEGMENT
__real@3ff0000000000000 DQ 03ff0000000000000r	; 1
CONST	ENDS
;	COMDAT __real@3f800000
CONST	SEGMENT
__real@3f800000 DD 03f800000r			; 1
CONST	ENDS
;	COMDAT __real@33d6bf95
CONST	SEGMENT
__real@33d6bf95 DD 033d6bf95r			; 1e-07
CONST	ENDS
;	COMDAT rtc$TMZ
rtc$TMZ	SEGMENT
__RTC_Shutdown.rtc$TMZ DD FLAT:__RTC_Shutdown
rtc$TMZ	ENDS
;	COMDAT rtc$IMZ
rtc$IMZ	SEGMENT
__RTC_InitBase.rtc$IMZ DD FLAT:__RTC_InitBase
rtc$IMZ	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\users\alisher\desktop\university\2018-2019 winter\cois2300\labs\lab 7\lab7\lab7\lab7.cpp
;	COMDAT _main
_TEXT	SEGMENT
_i$1 = -32						; size = 4
_sum$ = -20						; size = 4
_inc$ = -8						; size = 4
_main	PROC						; COMDAT

	push	ebp
	mov	ebp, esp
	sub	esp, 228				; 000000e4H
	push	ebx
	push	esi
	push	edi
	lea	edi, DWORD PTR [ebp-228]
	mov	ecx, 57					; 00000039H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	mov	ecx, OFFSET __0D6D97F6_lab7.cpp
	call	@__CheckForDebuggerJustMyCode@4

	mov	esi, esp
	push	0
	push	0
	mov	eax, DWORD PTR __imp_?cout@std@@3V?$basic_ostream@DU?$char_traits@D@std@@@1@A
	mov	ecx, DWORD PTR [eax]
	mov	edx, DWORD PTR __imp_?cout@std@@3V?$basic_ostream@DU?$char_traits@D@std@@@1@A
	add	edx, DWORD PTR [ecx+4]
	mov	ecx, edx
	call	DWORD PTR __imp_?precision@ios_base@std@@QAE_J_J@Z
	cmp	esi, esp
	call	__RTC_CheckEsp

	movss	xmm0, DWORD PTR __real@33d6bf95
	movss	DWORD PTR _inc$[ebp], xmm0
	xorps	xmm0, xmm0
	movss	DWORD PTR _sum$[ebp], xmm0

	movss	xmm0, DWORD PTR __real@3f800000
	movss	DWORD PTR _i$1[ebp], xmm0
$LN2@main:
	cvtss2sd xmm0, DWORD PTR _i$1[ebp]
	movsd	xmm1, QWORD PTR __real@416312d000000000
	comisd	xmm1, xmm0
	jb	SHORT $LN3@main

	cvtss2sd xmm0, DWORD PTR _i$1[ebp]
	movsd	xmm1, QWORD PTR __real@3ff0000000000000
	divsd	xmm1, xmm0
	cvtss2sd xmm0, DWORD PTR _sum$[ebp]
	addsd	xmm0, xmm1
	cvtsd2ss xmm0, xmm0
	movss	DWORD PTR _sum$[ebp], xmm0

	cvtss2sd xmm0, DWORD PTR _i$1[ebp]
	addsd	xmm0, QWORD PTR __real@3ff0000000000000
	cvtsd2ss xmm0, xmm0
	movss	DWORD PTR _i$1[ebp], xmm0

	jmp	SHORT $LN2@main
$LN3@main:

	mov	esi, esp
	push	ecx
	movss	xmm0, DWORD PTR _sum$[ebp]
	movss	DWORD PTR [esp], xmm0
	mov	ecx, DWORD PTR __imp_?cout@std@@3V?$basic_ostream@DU?$char_traits@D@std@@@1@A
	call	DWORD PTR __imp_??6?$basic_ostream@DU?$char_traits@D@std@@@std@@QAEAAV01@M@Z
	cmp	esi, esp
	call	__RTC_CheckEsp

	mov	esi, esp
	mov	ecx, DWORD PTR __imp_?cin@std@@3V?$basic_istream@DU?$char_traits@D@std@@@1@A
	call	DWORD PTR __imp_?get@?$basic_istream@DU?$char_traits@D@std@@@std@@QAEHXZ
	cmp	esi, esp
	call	__RTC_CheckEsp

	xor	eax, eax

	pop	edi
	pop	esi
	pop	ebx
	add	esp, 228				; 000000e4H
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	0
_main	ENDP
_TEXT	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\users\alisher\desktop\university\2018-2019 winter\cois2300\labs\lab 7\lab7\lab7\lab7.cpp
;	COMDAT ?__empty_global_delete@@YAXPAXI@Z
_TEXT	SEGMENT
___formal$ = 8						; size = 4
___formal$ = 12						; size = 4
?__empty_global_delete@@YAXPAXI@Z PROC			; __empty_global_delete, COMDAT

	push	ebp
	mov	ebp, esp
	sub	esp, 192				; 000000c0H
	push	ebx
	push	esi
	push	edi
	lea	edi, DWORD PTR [ebp-192]
	mov	ecx, 48					; 00000030H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	mov	ecx, OFFSET __0D6D97F6_lab7.cpp
	call	@__CheckForDebuggerJustMyCode@4
	pop	edi
	pop	esi
	pop	ebx
	add	esp, 192				; 000000c0H
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	0
?__empty_global_delete@@YAXPAXI@Z ENDP			; __empty_global_delete
_TEXT	ENDS
; Function compile flags: /Odtp /RTCsu /ZI
; File c:\users\alisher\desktop\university\2018-2019 winter\cois2300\labs\lab 7\lab7\lab7\lab7.cpp
;	COMDAT ?__empty_global_delete@@YAXPAX@Z
_TEXT	SEGMENT
___formal$ = 8						; size = 4
?__empty_global_delete@@YAXPAX@Z PROC			; __empty_global_delete, COMDAT

	push	ebp
	mov	ebp, esp
	sub	esp, 192				; 000000c0H
	push	ebx
	push	esi
	push	edi
	lea	edi, DWORD PTR [ebp-192]
	mov	ecx, 48					; 00000030H
	mov	eax, -858993460				; ccccccccH
	rep stosd
	mov	ecx, OFFSET __0D6D97F6_lab7.cpp
	call	@__CheckForDebuggerJustMyCode@4
	pop	edi
	pop	esi
	pop	ebx
	add	esp, 192				; 000000c0H
	cmp	ebp, esp
	call	__RTC_CheckEsp
	mov	esp, ebp
	pop	ebp
	ret	0
?__empty_global_delete@@YAXPAX@Z ENDP			; __empty_global_delete
_TEXT	ENDS
END