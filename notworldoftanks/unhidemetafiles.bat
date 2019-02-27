REM un-hide all of those pesky .meta files in the unity Assets dir and below

cd ./Assets

attrib -h *.meta /s
