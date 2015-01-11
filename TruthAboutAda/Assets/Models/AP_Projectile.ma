//Maya ASCII 2015 scene
//Name: AP_Projectile.ma
//Last modified: Sat, Jan 10, 2015 02:16:32 PM
//Codeset: UTF-8
requires maya "2015";
requires -nodeType "makeFePolyGear" "fePolyPrimitives2015" "0.9 beta";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2015";
fileInfo "version" "2015";
fileInfo "cutIdentifier" "201405190330-916664";
fileInfo "osv" "Mac OS X 10.9.1";
fileInfo "license" "student";
createNode transform -n "pCylinder1";
	setAttr ".t" -type "double3" -0.2 -1.2841996042114692 0.2 ;
createNode mesh -n "pCylinderShape1" -p "pCylinder1";
	setAttr -k off ".v";
	setAttr -s 4 ".iog";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50170722603797913 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pCylinder2";
	setAttr ".t" -type "double3" -0.2 -1.2841996042114692 -0.19967490172837854 ;
createNode transform -n "pCylinder3";
	setAttr ".t" -type "double3" 0.19980806725163908 -1.2841996042114692 -0.19967490172837854 ;
createNode transform -n "pCylinder4";
	setAttr ".t" -type "double3" 0.19980806725163908 -1.2841996042114692 0.20002474936898379 ;
createNode transform -n "pCube1";
	setAttr ".t" -type "double3" 0 -1.3473430363327781 0 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "fePolyGear";
	setAttr ".t" -type "double3" 0 -1.0384559907788486 0 ;
	setAttr ".s" -type "double3" 0.14125000377916019 0.14125000377916019 0.14125000377916019 ;
createNode mesh -n "fePolyGearShape" -p "fePolyGear";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "cylinder_axis1";
	setAttr ".t" -type "double3" 0 -0.96910885496993271 0 ;
	setAttr ".s" -type "double3" 1.6863093601511003 1 1.6863093601511003 ;
createNode mesh -n "cylinder_axis1Shape" -p "cylinder_axis1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49999998509883881 0.15624996274709702 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 124 ".uvst[0].uvsp[0:123]" -type "float2" 0.64860266 0.10796607
		 0.62640899 0.064408496 0.59184152 0.029841021 0.54828393 0.0076473355 0.5 -7.4505806e-08
		 0.45171607 0.0076473504 0.40815851 0.029841051 0.37359107 0.064408526 0.3513974 0.10796608
		 0.34374997 0.15625 0.3513974 0.20453392 0.37359107 0.24809146 0.40815854 0.28265893
		 0.4517161 0.3048526 0.5 0.3125 0.54828387 0.3048526 0.59184146 0.28265893 0.62640893
		 0.24809146 0.6486026 0.2045339 0.65625 0.15625 0.375 0.3125 0.38749999 0.3125 0.39999998
		 0.3125 0.41249996 0.3125 0.42499995 0.3125 0.43749994 0.3125 0.44999993 0.3125 0.46249992
		 0.3125 0.4749999 0.3125 0.48749989 0.3125 0.49999988 0.3125 0.51249987 0.3125 0.52499986
		 0.3125 0.53749985 0.3125 0.54999983 0.3125 0.56249982 0.3125 0.57499981 0.3125 0.5874998
		 0.3125 0.59999979 0.3125 0.61249977 0.3125 0.62499976 0.3125 0.375 0.68843985 0.38749999
		 0.68843985 0.39999998 0.68843985 0.41249996 0.68843985 0.42499995 0.68843985 0.43749994
		 0.68843985 0.44999993 0.68843985 0.46249992 0.68843985 0.4749999 0.68843985 0.48749989
		 0.68843985 0.49999988 0.68843985 0.51249987 0.68843985 0.52499986 0.68843985 0.53749985
		 0.68843985 0.54999983 0.68843985 0.56249982 0.68843985 0.57499981 0.68843985 0.5874998
		 0.68843985 0.59999979 0.68843985 0.61249977 0.68843985 0.62499976 0.68843985 0.64860266
		 0.79546607 0.62640899 0.75190848 0.59184152 0.71734101 0.54828393 0.69514734 0.5
		 0.68749994 0.45171607 0.69514734 0.40815851 0.71734107 0.37359107 0.75190854 0.3513974
		 0.79546607 0.34374997 0.84375 0.3513974 0.89203393 0.37359107 0.93559146 0.40815854
		 0.97015893 0.4517161 0.9923526 0.5 1 0.54828387 0.9923526 0.59184146 0.97015893 0.62640893
		 0.93559146 0.6486026 0.89203393 0.65625 0.84375 0.5 0.15000001 0.5 0.83749998 0.62640899
		 0.064408496 0.64860266 0.10796607 0.59184152 0.029841021 0.54828393 0.0076473355
		 0.5 -7.4505806e-08 0.45171607 0.0076473504 0.40815851 0.029841051 0.37359107 0.064408526
		 0.3513974 0.10796608 0.34374997 0.15625 0.3513974 0.20453392 0.37359107 0.24809146
		 0.40815854 0.28265893 0.4517161 0.3048526 0.5 0.3125 0.54828387 0.3048526 0.59184146
		 0.28265893 0.62640893 0.24809146 0.6486026 0.2045339 0.65625 0.15625 0.6486026 0.89203393
		 0.62640893 0.93559146 0.59184146 0.97015893 0.54828387 0.9923526 0.5 1 0.4517161
		 0.9923526 0.40815854 0.97015893 0.37359107 0.93559146 0.3513974 0.89203393 0.34374997
		 0.84375 0.3513974 0.79546607 0.37359107 0.75190854 0.40815851 0.71734107 0.45171607
		 0.69514734 0.5 0.68749994 0.54828393 0.69514734 0.59184152 0.71734101 0.62640899
		 0.75190848 0.64860266 0.79546607 0.65625 0.84375;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 42 ".pt";
	setAttr ".pt[0]" -type "float3" -1.3114509e-15 -10.317132 3.2786274e-16 ;
	setAttr ".pt[1]" -type "float3" -1.3114509e-15 -10.317132 6.5572547e-16 ;
	setAttr ".pt[2]" -type "float3" -6.5572547e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[3]" -type "float3" -3.2786274e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[4]" -type "float3" 0 -10.317132 1.3114509e-15 ;
	setAttr ".pt[5]" -type "float3" 3.2786274e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[6]" -type "float3" 6.5572547e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[7]" -type "float3" 1.3114509e-15 -10.317132 6.5572547e-16 ;
	setAttr ".pt[8]" -type "float3" 1.3114509e-15 -10.317132 3.2786274e-16 ;
	setAttr ".pt[9]" -type "float3" 1.3114509e-15 -10.317132 0 ;
	setAttr ".pt[10]" -type "float3" 1.3114509e-15 -10.317132 -3.2786274e-16 ;
	setAttr ".pt[11]" -type "float3" 1.3114509e-15 -10.317132 -6.5572547e-16 ;
	setAttr ".pt[12]" -type "float3" 6.5572547e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[13]" -type "float3" 3.2786274e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[14]" -type "float3" 3.9084284e-23 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[15]" -type "float3" -3.2786274e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[16]" -type "float3" -6.5572547e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[17]" -type "float3" -1.3114509e-15 -10.317132 -6.5572547e-16 ;
	setAttr ".pt[18]" -type "float3" -1.3114509e-15 -10.317132 -3.2786274e-16 ;
	setAttr ".pt[19]" -type "float3" -1.3114509e-15 -10.317132 0 ;
	setAttr ".pt[21]" -type "float3" 0 -1.8626451e-09 0 ;
	setAttr ".pt[40]" -type "float3" -1.3114509e-15 -10.317132 3.2786274e-16 ;
	setAttr ".pt[41]" -type "float3" -1.3114509e-15 -10.317132 6.5572547e-16 ;
	setAttr ".pt[42]" -type "float3" 0 -10.317132 -4.8855355e-24 ;
	setAttr ".pt[43]" -type "float3" -6.5572547e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[44]" -type "float3" -3.2786274e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[45]" -type "float3" 0 -10.317132 1.3114509e-15 ;
	setAttr ".pt[46]" -type "float3" 3.2786274e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[47]" -type "float3" 6.5572547e-16 -10.317132 1.3114509e-15 ;
	setAttr ".pt[48]" -type "float3" 1.3114509e-15 -10.317132 6.5572547e-16 ;
	setAttr ".pt[49]" -type "float3" 1.3114509e-15 -10.317132 3.2786274e-16 ;
	setAttr ".pt[50]" -type "float3" 1.3114509e-15 -10.317132 0 ;
	setAttr ".pt[51]" -type "float3" 1.3114509e-15 -10.317132 -3.2786274e-16 ;
	setAttr ".pt[52]" -type "float3" 1.3114509e-15 -10.317132 -6.5572547e-16 ;
	setAttr ".pt[53]" -type "float3" 6.5572547e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[54]" -type "float3" 3.2786274e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[55]" -type "float3" 7.8168568e-23 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[56]" -type "float3" -3.2786274e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[57]" -type "float3" -6.5572547e-16 -10.317132 -1.3114509e-15 ;
	setAttr ".pt[58]" -type "float3" -1.3114509e-15 -10.317132 -6.5572547e-16 ;
	setAttr ".pt[59]" -type "float3" -1.3114509e-15 -10.317132 -3.2786274e-16 ;
	setAttr ".pt[60]" -type "float3" -1.3114509e-15 -10.317132 3.1267427e-22 ;
	setAttr -s 82 ".vt[0:81]"  0.047552858 -0.025 -0.015450859 0.040450878 -0.025 -0.029389281
		 0.029389281 -0.025 -0.040450875 0.015450858 -0.025 -0.04755285 0 -0.025 -0.050000023
		 -0.015450858 -0.025 -0.04755285 -0.029389275 -0.025 -0.040450867 -0.040450864 -0.025 -0.029389272
		 -0.047552839 -0.025 -0.015450853 -0.050000012 -0.025 0 -0.047552839 -0.025 0.015450853
		 -0.04045086 -0.025 0.029389268 -0.029389268 -0.025 0.040450856 -0.015450853 -0.025 0.047552835
		 -1.4901161e-09 -0.025000002 0.050000008 0.015450849 -0.025000002 0.047552831 0.029389262 -0.025 0.040450852
		 0.040450852 -0.025 0.029389266 0.047552828 -0.025 0.01545085 0.050000001 -0.025 0
		 0.047552858 0.025 -0.015450859 0.040450878 0.024999999 -0.029389281 0.029389281 0.025 -0.040450875
		 0.015450858 0.025 -0.04755285 0 0.025 -0.050000023 -0.015450858 0.025 -0.04755285
		 -0.029389275 0.025 -0.040450867 -0.040450864 0.025 -0.029389272 -0.047552839 0.025 -0.015450853
		 -0.050000012 0.025 0 -0.047552839 0.025 0.015450853 -0.04045086 0.025 0.029389268
		 -0.029389268 0.025 0.040450856 -0.015450853 0.025 0.047552835 -1.4901161e-09 0.025 0.050000008
		 0.015450849 0.025 0.047552831 0.029389262 0.025 0.040450852 0.040450852 0.025 0.029389266
		 0.047552828 0.025 0.01545085 0.050000001 0.025 0 0.037923738 -0.035 -0.012322182
		 0.032259863 -0.035 -0.023438161 0 -0.035 1.7781586e-10 0.023438163 -0.035 -0.032259859
		 0.012322171 -0.035 -0.037923735 0 -0.035 -0.039875373 -0.012322168 -0.035 -0.037923735
		 -0.023438152 -0.035 -0.032259855 -0.032259848 -0.035 -0.023438154 -0.037923723 -0.035 -0.012322165
		 -0.039875362 -0.035 0 -0.037923723 -0.035 0.012322166 -0.032259844 -0.035 0.023438148
		 -0.023438148 -0.035 0.032259841 -0.012322164 -0.035 0.03792372 -2.6357385e-09 -0.035 0.039875358
		 0.012322159 -0.035 0.037923716 0.023438143 -0.035 0.032259837 0.032259837 -0.035 0.023438144
		 0.037923712 -0.035 0.012322162 0.039875351 -0.035 -8.4981879e-09 0.037923738 0.035 -0.012322182
		 0.032259863 0.035 -0.023438161 0 0.035 1.6123973e-10 0.023438163 0.035 -0.032259859
		 0.012322171 0.035 -0.037923735 0 0.035 -0.039875373 -0.012322168 0.035 -0.037923735
		 -0.023438152 0.035 -0.032259855 -0.032259848 0.035 -0.023438154 -0.037923723 0.035 -0.012322165
		 -0.039875362 0.035 0 -0.037923723 0.035 0.012322166 -0.032259844 0.035 0.023438148
		 -0.023438148 0.035 0.032259841 -0.012322164 0.035 0.03792372 -2.6357385e-09 0.035 0.039875358
		 0.012322159 0.035 0.037923716 0.023438143 0.035 0.032259837 0.032259837 0.035 0.023438143
		 0.037923712 0.035 0.012322162 0.039875351 0.035 -8.4981879e-09;
	setAttr -s 180 ".ed";
	setAttr ".ed[0:165]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0 7 8 0 8 9 0
		 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 16 0 16 17 0 17 18 0 18 19 0 19 0 0
		 20 21 0 21 22 0 22 23 0 23 24 0 24 25 0 25 26 0 26 27 0 27 28 0 28 29 0 29 30 0 30 31 0
		 31 32 0 32 33 0 33 34 0 34 35 0 35 36 0 36 37 0 37 38 0 38 39 0 39 20 0 0 20 1 1 21 1
		 2 22 1 3 23 1 4 24 1 5 25 1 6 26 1 7 27 1 8 28 1 9 29 1 10 30 1 11 31 1 12 32 1 13 33 1
		 14 34 1 15 35 1 16 36 1 17 37 1 18 38 1 19 39 1 0 40 1 1 41 1 40 41 0 42 40 1 42 41 1
		 2 43 1 41 43 0 42 43 1 3 44 1 43 44 0 42 44 1 4 45 1 44 45 0 42 45 1 5 46 1 45 46 0
		 42 46 1 6 47 1 46 47 0 42 47 1 7 48 1 47 48 0 42 48 1 8 49 1 48 49 0 42 49 1 9 50 1
		 49 50 0 42 50 1 10 51 1 50 51 0 42 51 1 11 52 1 51 52 0 42 52 1 12 53 1 52 53 0 42 53 1
		 13 54 1 53 54 0 42 54 1 14 55 1 54 55 0 42 55 1 15 56 1 55 56 0 42 56 1 16 57 1 56 57 0
		 42 57 1 17 58 1 57 58 0 42 58 1 18 59 1 58 59 0 42 59 1 19 60 1 59 60 0 42 60 1 60 40 0
		 20 61 1 21 62 1 61 62 0 62 63 1 61 63 1 22 64 1 62 64 0 64 63 1 23 65 1 64 65 0 65 63 1
		 24 66 1 65 66 0 66 63 1 25 67 1 66 67 0 67 63 1 26 68 1 67 68 0 68 63 1 27 69 1 68 69 0
		 69 63 1 28 70 1 69 70 0 70 63 1 29 71 1 70 71 0 71 63 1 30 72 1 71 72 0 72 63 1 31 73 1
		 72 73 0 73 63 1 32 74 1 73 74 0 74 63 1 33 75 1 74 75 0 75 63 1 34 76 1 75 76 0 76 63 1
		 35 77 1 76 77 0;
	setAttr ".ed[166:179]" 77 63 1 36 78 1 77 78 0 78 63 1 37 79 1 78 79 0 79 63 1
		 38 80 1 79 80 0 80 63 1 39 81 1 80 81 0 81 63 1 81 61 0;
	setAttr -s 100 -ch 360 ".fc[0:99]" -type "polyFaces" 
		f 4 0 41 -21 -41
		mu 0 4 20 21 42 41
		f 4 1 42 -22 -42
		mu 0 4 21 22 43 42
		f 4 2 43 -23 -43
		mu 0 4 22 23 44 43
		f 4 3 44 -24 -44
		mu 0 4 23 24 45 44
		f 4 4 45 -25 -45
		mu 0 4 24 25 46 45
		f 4 5 46 -26 -46
		mu 0 4 25 26 47 46
		f 4 6 47 -27 -47
		mu 0 4 26 27 48 47
		f 4 7 48 -28 -48
		mu 0 4 27 28 49 48
		f 4 8 49 -29 -49
		mu 0 4 28 29 50 49
		f 4 9 50 -30 -50
		mu 0 4 29 30 51 50
		f 4 10 51 -31 -51
		mu 0 4 30 31 52 51
		f 4 11 52 -32 -52
		mu 0 4 31 32 53 52
		f 4 12 53 -33 -53
		mu 0 4 32 33 54 53
		f 4 13 54 -34 -54
		mu 0 4 33 34 55 54
		f 4 14 55 -35 -55
		mu 0 4 34 35 56 55
		f 4 15 56 -36 -56
		mu 0 4 35 36 57 56
		f 4 16 57 -37 -57
		mu 0 4 36 37 58 57
		f 4 17 58 -38 -58
		mu 0 4 37 38 59 58
		f 4 18 59 -39 -59
		mu 0 4 38 39 60 59
		f 4 19 40 -40 -60
		mu 0 4 39 40 61 60
		f 3 -63 -64 64
		mu 0 3 84 85 82
		f 3 -67 -65 67
		mu 0 3 86 84 82
		f 3 -70 -68 70
		mu 0 3 87 86 82
		f 3 -73 -71 73
		mu 0 3 88 87 82
		f 3 -76 -74 76
		mu 0 3 89 88 82
		f 3 -79 -77 79
		mu 0 3 90 89 82
		f 3 -82 -80 82
		mu 0 3 91 90 82
		f 3 -85 -83 85
		mu 0 3 92 91 82
		f 3 -88 -86 88
		mu 0 3 93 92 82
		f 3 -91 -89 91
		mu 0 3 94 93 82
		f 3 -94 -92 94
		mu 0 3 95 94 82
		f 3 -97 -95 97
		mu 0 3 96 95 82
		f 3 -100 -98 100
		mu 0 3 97 96 82
		f 3 -103 -101 103
		mu 0 3 98 97 82
		f 3 -106 -104 106
		mu 0 3 99 98 82
		f 3 -109 -107 109
		mu 0 3 100 99 82
		f 3 -112 -110 112
		mu 0 3 101 100 82
		f 3 -115 -113 115
		mu 0 3 102 101 82
		f 3 -118 -116 118
		mu 0 3 103 102 82
		f 3 -120 -119 63
		mu 0 3 85 103 82
		f 3 122 123 -125
		mu 0 3 104 105 83
		f 3 126 127 -124
		mu 0 3 105 106 83
		f 3 129 130 -128
		mu 0 3 106 107 83
		f 3 132 133 -131
		mu 0 3 107 108 83
		f 3 135 136 -134
		mu 0 3 108 109 83
		f 3 138 139 -137
		mu 0 3 109 110 83
		f 3 141 142 -140
		mu 0 3 110 111 83
		f 3 144 145 -143
		mu 0 3 111 112 83
		f 3 147 148 -146
		mu 0 3 112 113 83
		f 3 150 151 -149
		mu 0 3 113 114 83
		f 3 153 154 -152
		mu 0 3 114 115 83
		f 3 156 157 -155
		mu 0 3 115 116 83
		f 3 159 160 -158
		mu 0 3 116 117 83
		f 3 162 163 -161
		mu 0 3 117 118 83
		f 3 165 166 -164
		mu 0 3 118 119 83
		f 3 168 169 -167
		mu 0 3 119 120 83
		f 3 171 172 -170
		mu 0 3 120 121 83
		f 3 174 175 -173
		mu 0 3 121 122 83
		f 3 177 178 -176
		mu 0 3 122 123 83
		f 3 179 124 -179
		mu 0 3 123 104 83
		f 4 -1 60 62 -62
		mu 0 4 1 0 85 84
		f 4 -2 61 66 -66
		mu 0 4 2 1 84 86
		f 4 -3 65 69 -69
		mu 0 4 3 2 86 87
		f 4 -4 68 72 -72
		mu 0 4 4 3 87 88
		f 4 -5 71 75 -75
		mu 0 4 5 4 88 89
		f 4 -6 74 78 -78
		mu 0 4 6 5 89 90
		f 4 -7 77 81 -81
		mu 0 4 7 6 90 91
		f 4 -8 80 84 -84
		mu 0 4 8 7 91 92
		f 4 -9 83 87 -87
		mu 0 4 9 8 92 93
		f 4 -10 86 90 -90
		mu 0 4 10 9 93 94
		f 4 -11 89 93 -93
		mu 0 4 11 10 94 95
		f 4 -12 92 96 -96
		mu 0 4 12 11 95 96
		f 4 -13 95 99 -99
		mu 0 4 13 12 96 97
		f 4 -14 98 102 -102
		mu 0 4 14 13 97 98
		f 4 -15 101 105 -105
		mu 0 4 15 14 98 99
		f 4 -16 104 108 -108
		mu 0 4 16 15 99 100
		f 4 -17 107 111 -111
		mu 0 4 17 16 100 101
		f 4 -18 110 114 -114
		mu 0 4 18 17 101 102
		f 4 -19 113 117 -117
		mu 0 4 19 18 102 103
		f 4 -20 116 119 -61
		mu 0 4 0 19 103 85
		f 4 20 121 -123 -121
		mu 0 4 80 79 105 104
		f 4 21 125 -127 -122
		mu 0 4 79 78 106 105
		f 4 22 128 -130 -126
		mu 0 4 78 77 107 106
		f 4 23 131 -133 -129
		mu 0 4 77 76 108 107
		f 4 24 134 -136 -132
		mu 0 4 76 75 109 108
		f 4 25 137 -139 -135
		mu 0 4 75 74 110 109
		f 4 26 140 -142 -138
		mu 0 4 74 73 111 110
		f 4 27 143 -145 -141
		mu 0 4 73 72 112 111
		f 4 28 146 -148 -144
		mu 0 4 72 71 113 112
		f 4 29 149 -151 -147
		mu 0 4 71 70 114 113
		f 4 30 152 -154 -150
		mu 0 4 70 69 115 114
		f 4 31 155 -157 -153
		mu 0 4 69 68 116 115
		f 4 32 158 -160 -156
		mu 0 4 68 67 117 116
		f 4 33 161 -163 -159
		mu 0 4 67 66 118 117
		f 4 34 164 -166 -162
		mu 0 4 66 65 119 118
		f 4 35 167 -169 -165
		mu 0 4 65 64 120 119
		f 4 36 170 -172 -168
		mu 0 4 64 63 121 120
		f 4 37 173 -175 -171
		mu 0 4 63 62 122 121
		f 4 38 176 -178 -174
		mu 0 4 62 81 123 122
		f 4 39 120 -180 -177
		mu 0 4 81 80 104 123;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
parent -s -nc -r -add "|pCylinder1|pCylinderShape1" "pCylinder2" ;
parent -s -nc -r -add "|pCylinder1|pCylinderShape1" "pCylinder3" ;
parent -s -nc -r -add "|pCylinder1|pCylinderShape1" "pCylinder4" ;
createNode displayLayer -n "layer1";
	setAttr ".do" 1;
createNode displayLayerManager -n "layerManager";
	setAttr ".cdl" 3;
	setAttr -s 5 ".dli[1:4]"  3 2 0 1;
	setAttr -s 3 ".dli";
createNode polyExtrudeFace -n "polyExtrudeFace6";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 1 "f[15:44]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -0.20000000000000001 -0.59897391947297229 0.20000000000000001 1;
	setAttr ".ws" yes;
	setAttr ".rs" 1588573434;
	setAttr ".lt" -type "double3" 0 0 0.01 ;
	setAttr ".off" 0.0099999997764825821;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.24890737682580949 -0.70397391619471683 0.15027391240000726 ;
	setAttr ".cbx" -type "double3" -0.14999999925494195 -0.49397392275122776 0.24972609132528306 ;
createNode polyCylinder -n "polyCylinder2";
	setAttr ".r" 0.04;
	setAttr ".h" 0.21000000000000002;
	setAttr ".sa" 15;
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[3]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 -0.69401236860917226 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 1940348747;
	setAttr ".lt" -type "double3" 0 0 0.01 ;
	setAttr ".off" 0.0099999997764825821;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.27500000596046448 -0.72401233999894277 -0.27500000596046448 ;
	setAttr ".cbx" -type "double3" 0.27500000596046448 -0.66401239721940175 0.27500000596046448 ;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 -0.69401236860917226 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 1994989619;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.27500000596046448 -0.65401234715150014 -0.27500000596046448 ;
	setAttr ".cbx" -type "double3" 0.27500000596046448 -0.65401234715150014 0.27500000596046448 ;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 1 "f[3]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 -0.69401236860917226 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 1481299606;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.27500000596046448 -0.73401239006684438 -0.27500000596046448 ;
	setAttr ".cbx" -type "double3" 0.27500000596046448 -0.73401239006684438 0.27500000596046448 ;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 1 "f[3]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 -0.69401236860917226 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 1387416987;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.27500000596046448 -0.73401239006684438 -0.27500000596046448 ;
	setAttr ".cbx" -type "double3" 0.27500000596046448 -0.73401239006684438 0.27500000596046448 ;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	setAttr ".cch" yes;
	setAttr ".ics" -type "componentList" 1 "f[3]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 -0.69401236860917226 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 2032535809;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.27500000596046448 -0.73401236771510259 -0.27500000596046448 ;
	setAttr ".cbx" -type "double3" 0.27500000596046448 -0.73401236771510259 0.27500000596046448 ;
createNode polyCube -n "polyCube1";
	setAttr ".w" 0.55;
	setAttr ".h" 0.06;
	setAttr ".d" 0.55;
	setAttr ".cuv" 4;
createNode makeFePolyGear -n "makeFePolyGear1";
	setAttr ".br" 0.48951048495156779;
	setAttr ".cw" 0.8;
	setAttr ".c" 15;
	setAttr ".h" 1.1188811270871779;
	setAttr ".px" -type "double3" 0 0 0 ;
createNode displayLayer -n "layer2";
	setAttr ".do" 2;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 4 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 2 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 2 ".tx";
select -ne :initialShadingGroup;
	setAttr -s 31 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 13 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "layer1.di" "pCylinder1.do";
connectAttr "polyExtrudeFace6.out" "|pCylinder1|pCylinderShape1.i";
connectAttr "layer1.di" "pCylinder2.do";
connectAttr "layer1.di" "pCylinder3.do";
connectAttr "layer1.di" "pCylinder4.do";
connectAttr "layer1.di" "pCube1.do";
connectAttr "polyExtrudeFace11.out" "pCubeShape1.i";
connectAttr "makeFePolyGear1.out" "fePolyGearShape.i";
connectAttr "layer2.di" "cylinder_axis1.do";
connectAttr "layerManager.dli[1]" "layer1.id";
connectAttr "polyCylinder2.out" "polyExtrudeFace6.ip";
connectAttr "|pCylinder1|pCylinderShape1.wm" "polyExtrudeFace6.mp";
connectAttr "polyExtrudeFace10.out" "polyExtrudeFace11.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace11.mp";
connectAttr "polyExtrudeFace9.out" "polyExtrudeFace10.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace8.out" "polyExtrudeFace9.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace9.mp";
connectAttr "polyExtrudeFace7.out" "polyExtrudeFace8.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace8.mp";
connectAttr "polyCube1.out" "polyExtrudeFace7.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace7.mp";
connectAttr "layerManager.dli[4]" "layer2.id";
connectAttr "|pCylinder1|pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "|pCylinder2|pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "|pCylinder3|pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "|pCylinder4|pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "fePolyGearShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "cylinder_axis1Shape.iog" ":initialShadingGroup.dsm" -na;
// End of AP_Projectile.ma
