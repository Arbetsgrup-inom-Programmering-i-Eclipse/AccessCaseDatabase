# AccesCaseDatabase
Läs databasen med alla fall som man har sparat med "SaveCaseToDatabase"

Detta ska ändras:

i "Main.cs" rad 26: domain där er AD konto ligger. Detta kan hittas genom att köra "set user" kommandon i en konsol (CMD)
rad 30-31: kolla att samma user group gäller för ert sjukhus. Kör "gpresult /R" kommandon i konsolen och se om det finns en grupp "Varien Users" eller liknande i listan under raden "The user is a part of the following security groups"
i "MainView.cs" rad 13: path till databasen (.xml fil) som man använder i scriptet "SaveCaseToDatabase"
i "AriaInterface.cs" rad 8-10-12-14: ipaddress/servernamn till Aria databaserna
