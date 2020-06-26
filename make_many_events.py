import os
from time import sleep

while True:
    sleep(1)
    os.system('eventcreate /t INFORMATION /id 123 /d "ciao"')