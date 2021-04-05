#!/bin/bash
function strlen () {
if [[  -z "$1" ]]
then echo "error write string"
else expr length "$1"
fi
}
