# currency convert

# a currency converter that asks for a quantity of money, 
# asks for the currency for which it will be exchanged, 
# gives the option to enter the value of said currency 
# and launches the result
        
# dolar function
def dolarF():
    print ("What is dolar price?")
    global Dprice
    Dprice = input()
    Dprice = float(Dprice)
    global total
    total = cash / Dprice
    print ("You have ", total, "dolare(s)")

# euro function
def euroF():
    print ("What is euro price?")
    global Eprice
    Eprice = input()
    Eprice = float(Eprice)
    global total
    total = cash / Eprice
    print ("You have ", total, " euro(s)")

# esterlina function
def esterlinaF():
    print ("What is esterlina price?")
    global ESprice
    ESprice = input()
    ESprice = float(ESprice)
    global total
    total = cash / ESprice
    print ("You have: ", total, " esterlina(s)")


# main options
def main():
    print ("How many cash you have? (DOP)")
    global cash
    cash = input()
    cash = float(cash)
    print ("What change you wanna?")
    print ("1. Dolar")
    print ("2. Euros")
    print ("3. Esterlina")
    print ("0. Quit")
    global change
    change = input()
    change = int (change)
    # filter options
    if(change == 1):
        # call dollar function
        dolarF()
    elif(change == 2):
        # call euro function
        euroF()
    elif(change == 3):
        # call esterlina function
        esterlinaF()
    elif(change==0):
        print ("Thanks for using currency convert")
    else:
        print ("This opcion not exist!!!")
    print ("Wanna convert again? (yes/no)")
    global res
    res = input()
    res = res.lower()
    againConvert()
    
def againConvert():
    while(res!="no"):
        main()

# call main function
main()