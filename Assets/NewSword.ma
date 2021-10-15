//Maya ASCII 2018 scene
//Name: NewSword.ma
//Last modified: Sun, Jan 31, 2021 06:30:00 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pCylinder1";
	rename -uid "C51DAED5-47F1-42B7-EB81-5AAA54FB658C";
	setAttr ".t" -type "double3" 0 2.579561996805841 0 ;
	setAttr ".s" -type "double3" 0.14210941331419683 1.5932257505228722 0.14210941331419683 ;
createNode mesh -n "pCylinderShape1" -p "pCylinder1";
	rename -uid "02867D17-46F3-9CEB-AB0F-3988BE4B7D95";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.84374997019767761 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 41 ".pt";
	setAttr ".pt[100]" -type "float3" 0.071966797 -0.080016479 -0.023383379 ;
	setAttr ".pt[101]" -type "float3" 0.061218496 -0.080016479 -0.04447785 ;
	setAttr ".pt[102]" -type "float3" 0.04447785 -0.080016479 -0.061218355 ;
	setAttr ".pt[103]" -type "float3" 0.023383413 -0.080016479 -0.071966834 ;
	setAttr ".pt[104]" -type "float3" 9.0205745e-09 -0.080016479 -0.075670056 ;
	setAttr ".pt[105]" -type "float3" -0.023383409 -0.080016479 -0.071966834 ;
	setAttr ".pt[106]" -type "float3" -0.04447782 -0.080016479 -0.061218359 ;
	setAttr ".pt[107]" -type "float3" -0.061218359 -0.080016479 -0.044477798 ;
	setAttr ".pt[108]" -type "float3" -0.071966499 -0.080016479 -0.023383316 ;
	setAttr ".pt[109]" -type "float3" -0.075670034 -0.080016479 2.9817535e-08 ;
	setAttr ".pt[110]" -type "float3" -0.071966499 -0.080016479 0.023383429 ;
	setAttr ".pt[111]" -type "float3" -0.061218418 -0.080016479 0.04447785 ;
	setAttr ".pt[112]" -type "float3" -0.044477798 -0.080016479 0.061218385 ;
	setAttr ".pt[113]" -type "float3" -0.023383345 -0.080016479 0.071966834 ;
	setAttr ".pt[114]" -type "float3" 6.765454e-09 -0.080016479 0.075670265 ;
	setAttr ".pt[115]" -type "float3" 0.023383409 -0.080016479 0.071966849 ;
	setAttr ".pt[116]" -type "float3" 0.04447782 -0.080016479 0.061218388 ;
	setAttr ".pt[117]" -type "float3" 0.061218359 -0.080016479 0.04447785 ;
	setAttr ".pt[118]" -type "float3" 0.071966499 -0.080016479 0.023383435 ;
	setAttr ".pt[119]" -type "float3" 0.075670034 -0.080016479 2.9817535e-08 ;
	setAttr ".pt[120]" -type "float3" 0.4566018 -0.073922604 -0.14835881 ;
	setAttr ".pt[121]" -type "float3" 0.38840851 -0.073922604 -0.28219524 ;
	setAttr ".pt[122]" -type "float3" 0.2821953 -0.073922604 -0.38840833 ;
	setAttr ".pt[123]" -type "float3" 0.1483589 -0.073922604 -0.45660162 ;
	setAttr ".pt[124]" -type "float3" 5.723226e-08 -0.073922604 -0.48009914 ;
	setAttr ".pt[125]" -type "float3" -0.14835884 -0.073922604 -0.45660162 ;
	setAttr ".pt[126]" -type "float3" -0.28219521 -0.073922604 -0.3884083 ;
	setAttr ".pt[127]" -type "float3" -0.3884083 -0.073922604 -0.28219518 ;
	setAttr ".pt[128]" -type "float3" -0.45660126 -0.073922604 -0.14835872 ;
	setAttr ".pt[129]" -type "float3" -0.48009899 -0.073922604 8.5848427e-08 ;
	setAttr ".pt[130]" -type "float3" -0.45660126 -0.073922604 0.14835888 ;
	setAttr ".pt[131]" -type "float3" -0.3884083 -0.073922604 0.28219524 ;
	setAttr ".pt[132]" -type "float3" -0.28219518 -0.073922604 0.38840833 ;
	setAttr ".pt[133]" -type "float3" -0.14835875 -0.073922604 0.45660162 ;
	setAttr ".pt[134]" -type "float3" 4.2924214e-08 -0.073922604 0.48009935 ;
	setAttr ".pt[135]" -type "float3" 0.14835884 -0.073922604 0.45660162 ;
	setAttr ".pt[136]" -type "float3" 0.28219521 -0.073922604 0.38840833 ;
	setAttr ".pt[137]" -type "float3" 0.3884083 -0.073922604 0.28219524 ;
	setAttr ".pt[138]" -type "float3" 0.45660126 -0.073922604 0.14835887 ;
	setAttr ".pt[139]" -type "float3" 0.48009899 -0.073922604 8.5848427e-08 ;
	setAttr ".pt[141]" -type "float3" 5.723226e-08 -0.073922604 8.5848427e-08 ;
createNode transform -n "pCube1";
	rename -uid "7E4EA76E-4243-63E6-A7B4-179782B94AA0";
	setAttr ".t" -type "double3" 0 4.4462913637474246 0 ;
	setAttr ".s" -type "double3" 0.44591693303403268 0.80847927636717909 2.3607287163405131 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "F5DEBAFE-40FC-060A-06A7-6482C0F150EF";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 50 ".pt";
	setAttr ".pt[0]" -type "float3" 0.35919452 0.35454288 0.10574429 ;
	setAttr ".pt[1]" -type "float3" 0.17959726 0.35454288 0.10574429 ;
	setAttr ".pt[2]" -type "float3" 0 0.35454288 0.10574429 ;
	setAttr ".pt[3]" -type "float3" -0.17959726 0.35454288 0.10574429 ;
	setAttr ".pt[4]" -type "float3" -0.35919452 0.35454288 0.10574429 ;
	setAttr ".pt[5]" -type "float3" 0.35919452 0.17727144 0.10574429 ;
	setAttr ".pt[6]" -type "float3" 0.17959726 0.17727144 0.10574429 ;
	setAttr ".pt[7]" -type "float3" 0 0.17727144 0.10574429 ;
	setAttr ".pt[8]" -type "float3" -0.17959726 0.17727144 0.10574429 ;
	setAttr ".pt[9]" -type "float3" -0.35919452 0.17727144 0.10574429 ;
	setAttr ".pt[10]" -type "float3" 0.35919452 0 0.10574429 ;
	setAttr ".pt[11]" -type "float3" 0.17959726 0 0.10574429 ;
	setAttr ".pt[12]" -type "float3" 0 0 0.10574429 ;
	setAttr ".pt[13]" -type "float3" -0.17959726 0 0.10574429 ;
	setAttr ".pt[14]" -type "float3" -0.35919452 0 0.10574429 ;
	setAttr ".pt[15]" -type "float3" 0.35919452 -0.17727144 0.10574429 ;
	setAttr ".pt[16]" -type "float3" 0.17959726 -0.17727144 0.10574429 ;
	setAttr ".pt[17]" -type "float3" 0 -0.17727144 0.10574429 ;
	setAttr ".pt[18]" -type "float3" -0.17959726 -0.17727144 0.10574429 ;
	setAttr ".pt[19]" -type "float3" -0.35919452 -0.17727144 0.10574429 ;
	setAttr ".pt[20]" -type "float3" 0.35919452 -0.35454288 0.10574429 ;
	setAttr ".pt[21]" -type "float3" 0.17959726 -0.35454288 0.10574429 ;
	setAttr ".pt[22]" -type "float3" 0 -0.35454288 0.10574429 ;
	setAttr ".pt[23]" -type "float3" -0.17959726 -0.35454288 0.10574429 ;
	setAttr ".pt[24]" -type "float3" -0.35919452 -0.35454288 0.10574429 ;
	setAttr ".pt[40]" -type "float3" 0.35919455 -0.35454288 -0.10574429 ;
	setAttr ".pt[41]" -type "float3" 0.17959727 -0.35454288 -0.10574429 ;
	setAttr ".pt[42]" -type "float3" 0 -0.35454288 -0.10574429 ;
	setAttr ".pt[43]" -type "float3" -0.17959727 -0.35454288 -0.10574429 ;
	setAttr ".pt[44]" -type "float3" -0.35919455 -0.35454288 -0.10574429 ;
	setAttr ".pt[45]" -type "float3" 0.35919455 -0.17727144 -0.10574429 ;
	setAttr ".pt[46]" -type "float3" 0.17959727 -0.17727144 -0.10574429 ;
	setAttr ".pt[47]" -type "float3" 0 -0.17727144 -0.10574429 ;
	setAttr ".pt[48]" -type "float3" -0.17959727 -0.17727144 -0.10574429 ;
	setAttr ".pt[49]" -type "float3" -0.35919455 -0.17727144 -0.10574429 ;
	setAttr ".pt[50]" -type "float3" 0.35919455 0 -0.10574429 ;
	setAttr ".pt[51]" -type "float3" 0.17959727 0 -0.10574429 ;
	setAttr ".pt[52]" -type "float3" 0 0 -0.10574429 ;
	setAttr ".pt[53]" -type "float3" -0.17959727 0 -0.10574429 ;
	setAttr ".pt[54]" -type "float3" -0.35919455 0 -0.10574429 ;
	setAttr ".pt[55]" -type "float3" 0.35919455 0.17727144 -0.10574429 ;
	setAttr ".pt[56]" -type "float3" 0.17959727 0.17727144 -0.10574429 ;
	setAttr ".pt[57]" -type "float3" 0 0.17727144 -0.10574429 ;
	setAttr ".pt[58]" -type "float3" -0.17959727 0.17727144 -0.10574429 ;
	setAttr ".pt[59]" -type "float3" -0.35919455 0.17727144 -0.10574429 ;
	setAttr ".pt[60]" -type "float3" 0.35919455 0.35454288 -0.10574429 ;
	setAttr ".pt[61]" -type "float3" 0.17959727 0.35454288 -0.10574429 ;
	setAttr ".pt[62]" -type "float3" 0 0.35454288 -0.10574429 ;
	setAttr ".pt[63]" -type "float3" -0.17959727 0.35454288 -0.10574429 ;
	setAttr ".pt[64]" -type "float3" -0.35919455 0.35454288 -0.10574429 ;
createNode transform -n "pCube2";
	rename -uid "3A2E3D4E-427D-0992-3F33-B2A0DC935427";
	setAttr ".t" -type "double3" 0 7.7891054224892482 0 ;
	setAttr ".s" -type "double3" 0.12888502647074021 5.9652760420207702 0.86474957339774761 ;
createNode mesh -n "pCubeShape2" -p "pCube2";
	rename -uid "FD5D0E76-4C37-DAB0-6E25-9DB62BE2E8FD";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.12500000558793545 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 72 ".pt";
	setAttr ".pt[4]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[5]" -type "float3" 0.16666664 0 0.074914694 ;
	setAttr ".pt[6]" -type "float3" -0.16666667 0 0.074914694 ;
	setAttr ".pt[7]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[8]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[9]" -type "float3" 0.16666664 0 0.074914694 ;
	setAttr ".pt[10]" -type "float3" -0.16666667 0 0.074914694 ;
	setAttr ".pt[11]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[13]" -type "float3" 0.16666664 0 0.074914694 ;
	setAttr ".pt[14]" -type "float3" -0.16666667 0 0.074914694 ;
	setAttr ".pt[17]" -type "float3" 0.16666664 0 0.074914694 ;
	setAttr ".pt[18]" -type "float3" -0.16666667 0 0.074914694 ;
	setAttr ".pt[20]" -type "float3" 0.094075993 0 0 ;
	setAttr ".pt[21]" -type "float3" 0.16666664 0 0.074914694 ;
	setAttr ".pt[22]" -type "float3" -0.16666667 0 0.074914694 ;
	setAttr ".pt[23]" -type "float3" -0.094075993 0 0 ;
	setAttr ".pt[44]" -type "float3" 0.094075993 0 0 ;
	setAttr ".pt[45]" -type "float3" 0.16666664 0 -0.074914761 ;
	setAttr ".pt[46]" -type "float3" -0.16666667 0 -0.074914761 ;
	setAttr ".pt[47]" -type "float3" -0.094075993 0 0 ;
	setAttr ".pt[49]" -type "float3" 0.16666664 0 -0.074914761 ;
	setAttr ".pt[50]" -type "float3" -0.16666667 0 -0.074914731 ;
	setAttr ".pt[53]" -type "float3" 0.16666664 0 -0.074914731 ;
	setAttr ".pt[54]" -type "float3" -0.16666667 0 -0.074914731 ;
	setAttr ".pt[56]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[57]" -type "float3" 0.16666664 0 -0.074914694 ;
	setAttr ".pt[58]" -type "float3" -0.16666667 0 -0.074914694 ;
	setAttr ".pt[59]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[60]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[61]" -type "float3" 0.16666664 0 -0.074914694 ;
	setAttr ".pt[62]" -type "float3" -0.16666667 0 -0.074914694 ;
	setAttr ".pt[63]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[80]" -type "float3" 0.60174942 0 0 ;
	setAttr ".pt[81]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[82]" -type "float3" 0.60174942 0 0 ;
	setAttr ".pt[83]" -type "float3" 0.60174942 0 0 ;
	setAttr ".pt[84]" -type "float3" 0.10868874 0 0 ;
	setAttr ".pt[85]" -type "float3" 0.60174942 0 0 ;
	setAttr ".pt[86]" -type "float3" 0.40501931 0 0 ;
	setAttr ".pt[88]" -type "float3" 0.40501931 0 0 ;
	setAttr ".pt[89]" -type "float3" 0.40501931 0 0 ;
	setAttr ".pt[91]" -type "float3" 0.40501931 0 0 ;
	setAttr ".pt[92]" -type "float3" 0.23473731 0 0 ;
	setAttr ".pt[93]" -type "float3" -0.094075993 0 0 ;
	setAttr ".pt[94]" -type "float3" 0.23473731 0 0 ;
	setAttr ".pt[95]" -type "float3" -0.60174942 0 0 ;
	setAttr ".pt[96]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[97]" -type "float3" -0.60174942 0 0 ;
	setAttr ".pt[98]" -type "float3" -0.60174942 0 0 ;
	setAttr ".pt[99]" -type "float3" -0.10868874 0 0 ;
	setAttr ".pt[100]" -type "float3" -0.60174942 0 0 ;
	setAttr ".pt[101]" -type "float3" -0.40501931 0 0 ;
	setAttr ".pt[103]" -type "float3" -0.40501931 0 0 ;
	setAttr ".pt[104]" -type "float3" -0.40501931 0 0 ;
	setAttr ".pt[106]" -type "float3" -0.40501931 0 0 ;
	setAttr ".pt[107]" -type "float3" -0.23473731 0 0 ;
	setAttr ".pt[108]" -type "float3" 0.094075993 0 0 ;
	setAttr ".pt[109]" -type "float3" -0.23473731 0 0 ;
	setAttr ".pt[110]" -type "float3" -0.10868871 0 0.34360966 ;
	setAttr ".pt[111]" -type "float3" 0.16666664 0 0.45718709 ;
	setAttr ".pt[112]" -type "float3" -0.16666667 0 0.45718709 ;
	setAttr ".pt[113]" -type "float3" 0.10868871 0 0.34360972 ;
	setAttr ".pt[114]" -type "float3" 0.6017493 0 0.17180485 ;
	setAttr ".pt[115]" -type "float3" 0.10868871 0 -1.2304533e-07 ;
	setAttr ".pt[116]" -type "float3" 0.6017493 0 -0.17180519 ;
	setAttr ".pt[117]" -type "float3" 0.10868871 0 -0.34360966 ;
	setAttr ".pt[118]" -type "float3" -0.16666667 0 -0.45718703 ;
	setAttr ".pt[119]" -type "float3" 0.16666664 0 -0.45718703 ;
	setAttr ".pt[120]" -type "float3" -0.10868871 0 -0.34360966 ;
	setAttr ".pt[121]" -type "float3" -0.6017493 0 -0.17180519 ;
	setAttr ".pt[122]" -type "float3" -0.10868871 0 -1.2304533e-07 ;
	setAttr ".pt[123]" -type "float3" -0.6017493 0 0.17180516 ;
createNode polySplit -n "polySplit1";
	rename -uid "C8DC4C21-48F3-1D2D-F50C-D39A12975C2E";
	setAttr -s 15 ".e[0:14]"  0.45230699 0.45230699 0.45230699 0.45230699
		 0.45230699 0.45230699 0.45230699 0.54769301 0.54769301 0.54769301 0.54769301 0.45230699
		 0.45230699 0.45230699 0.45230699;
	setAttr -s 15 ".d[0:14]"  -2147483584 -2147483583 -2147483582 -2147483581 -2147483483 -2147483484 
		-2147483485 -2147483529 -2147483530 -2147483531 -2147483532 -2147483447 -2147483446 -2147483445 -2147483584;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak1";
	rename -uid "6FE9FCED-4155-3FE3-AAF0-CBB70DBEC3D4";
	setAttr ".uopa" yes;
	setAttr -s 126 ".tk[4:129]" -type "float3"  0 0.1302653 0.16579558 0 0.1302653
		 0.16579473 0 0.1302653 0.16579473 0 0.1302653 0.16579473 0 0.18553048 0.16579479
		 0 0.18553048 0.16579479 0 0.18553048 0.16579479 0 0.18553048 0.16579479 0 0.24079582
		 0.16579473 0 0.24079582 0.16579473 0 0.24079582 0.16579473 0 0.24079582 0.16579473
		 0 0.2960611 0.16579473 0 0.2960611 0.16579473 0 0.2960611 0.16579473 0 0.2960611
		 0.16579473 0 0.35132635 0.16579473 0 0.35132635 0.16579473 0 0.35132635 0.16579473
		 0 0.35132635 0.16579473 0.48779616 0.40659153 -0.48374996 0.16259874 0.40659153 -0.48374996
		 -0.16259877 0.40659153 -0.48374996 -0.48779616 0.40659153 -0.48374996 0.48779616
		 0.40659153 -0.24187519 0.16259874 0.40659153 -0.24187519 -0.16259877 0.40659153 -0.24187519
		 -0.48779616 0.40659153 -0.24187519 0.48779616 0.40659153 -4.186721e-07 0.16259874
		 0.40659153 -4.186721e-07 -0.16259877 0.40659153 -4.186721e-07 -0.48779616 0.40659153
		 -4.1286046e-07 0.48779616 0.40659153 0.24187435 0.16259874 0.40659153 0.24187435
		 -0.16259877 0.40659153 0.24187435 -0.48779616 0.40659153 0.24187435 0.48779616 0.40659153
		 0.48374912 0.16259874 0.40659153 0.48374912 -0.16259877 0.40659153 0.48374912 -0.48779616
		 0.40659153 0.48374912 0 0.35132635 -0.16579558 0 0.35132635 -0.16579534 0 0.35132635
		 -0.16579534 0 0.35132635 -0.16579534 0 0.2960611 -0.16579534 0 0.2960611 -0.16579534
		 0 0.2960611 -0.16579506 0 0.2960611 -0.16579506 0 0.24079582 -0.16579506 0 0.24079582
		 -0.16579506 0 0.24079582 -0.16579506 0 0.24079582 -0.16579473 0 0.18553048 -0.16579479
		 0 0.18553048 -0.16579479 0 0.18553048 -0.16579479 0 0.18553048 -0.16579479 0 0.1302653
		 -0.16579473 0 0.1302653 -0.16579473 0 0.1302653 -0.16579473 0 0.1302653 -0.16579473
		 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07
		 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07
		 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07 0 0 5.9604645e-07
		 0 0 5.9604645e-07 0 0.1302653 -0.08289779 0 0.1302653 0 0 0.1302653 0.08289779 0
		 0.18553048 -0.082897693 0 0.18553048 0 0 0.18553048 0.082897693 0 0.24079582 -0.08289779
		 0 0.24079582 0 0 0.24079582 0.08289779 0 0.2960611 -0.08289779 0 0.2960611 0 0 0.2960611
		 0.08289779 0 0.35132635 -0.08289779 0 0.35132635 0 0 0.35132635 0.08289779 0 0.1302653
		 -0.08289779 0 0.1302653 0 0 0.1302653 0.08289779 0 0.18553048 -0.082897693 0 0.18553048
		 0 0 0.18553048 0.08289817 0 0.24079582 -0.08289779 0 0.24079582 -3.9684508e-07 0
		 0.24079582 0.082898177 0 0.2960611 -0.08289779 0 0.2960611 -3.9684508e-07 0 0.2960611
		 0.082898177 0 0.35132635 -0.08289779 0 0.35132635 -3.9684508e-07 0 0.35132635 0.082898177
		 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07
		 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07
		 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07 0 0 0 0 0 -2.9802322e-07 0 0 2.9802322e-07
		 0 0 0 0 0 -2.9802322e-07;
createNode polyCube -n "polyCube2";
	rename -uid "31507FAC-4D9D-858F-9745-28B56E754195";
	setAttr ".sw" 3;
	setAttr ".sh" 6;
	setAttr ".sd" 4;
	setAttr ".cuv" 4;
createNode polyCube -n "polyCube1";
	rename -uid "2B77C723-46FA-A1B9-5213-4C9852598158";
	setAttr ".sw" 4;
	setAttr ".sh" 4;
	setAttr ".sd" 4;
	setAttr ".cuv" 4;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "91189B3D-44D7-DBB4-00BC-5096936E2E16";
	setAttr ".sh" 6;
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polyCylinder1.out" "pCylinderShape1.i";
connectAttr "polyCube1.out" "pCubeShape1.i";
connectAttr "polySplit1.out" "pCubeShape2.i";
connectAttr "polyTweak1.out" "polySplit1.ip";
connectAttr "polyCube2.out" "polyTweak1.ip";
connectAttr "pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.iog" ":initialShadingGroup.dsm" -na;
// End of NewSword.ma
