#!/bin/bash

NOW=$(date +"%m-%d-%Y-%H-%M")
mkdir -p ~/test && echo "catalog test was created successfully" >> ~/report && touch ~/test/$NOW
ping www.net_nikogo.ru || echo "${NOW} Error" >>  ~/report
