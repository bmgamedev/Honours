:start 

@ECHO OFF
CLS

ECHO Enter the grammar folder to be updated
SET /p folder="> "

CD C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\%folder%\
ECHO %CD%

IF EXIST *.g4 (
	IF EXIST *.interp (
		DEL *.interp
	)
	IF EXIST *.tokens (
		DEL *.tokens
	)
	IF EXIST *.cs (
		DEL *.cs
	)
	java org.antlr.v4.Tool -Dlanguage=CSharp proto101.g4
	
	ECHO Grammar files updated. Now checking for game files...
	
	IF EXIST C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Games\%folder%\ (
		CD C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Games\%folder%\Assets\Grammar\
		
		DEL /Q *.*
		
		XCOPY C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\%folder%\*.cs C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Games\%folder%\Assets\Grammar\ /Y
		XCOPY C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\%folder%\*.tokens C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Games\%folder%\Assets\Grammar\ /Y
		XCOPY C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\%folder%\*.g4 C:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Games\%folder%\Assets\Grammar\ /Y
		
		ECHO Game grammar files now updated
	)
	
) ELSE (
	ECHO No grammar files found
)


PAUSE
GOTO start