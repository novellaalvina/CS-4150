import string #Python module for strings. It contains a collection of string constants
import random #Python's module for generating random objects
lowercase_letters = string.ascii_lowercase #A constant containing lowercase letters
uppercase_letters = string.ascii_uppercase #A constant containing uppercase letters
letters = string.ascii_letters #A contstant containing all uppercase and lowercase letters
def lowercase_word(number = 5): #The function responsible for generating #random words which are in uppercase word = '' 
    #The variable which will hold the random word
    while len(word) != number: #While loop
        word += random.choice(lowercase_letters)
    return word
a = lowercase_word(number=5)
print(a)
