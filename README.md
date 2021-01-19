# scrapper_
Jesteś zażenowany aktualną dostępnością kart graficznych i innych komponentów w sklepach komputerowych?
Jeśli tak, to dobrze trafiłeś!

![meme](https://i.ibb.co/JKrwgYK/xdxdxdxdxd.jpg)

**PROGRAM MOŻESZ POBRAĆ Z PRAWEJ STRONY ZAKŁADKA RELEASES**

Napisałem prosty ~~cienki~~ program do sprawdzania dostępności różnych komponentów.

Program obsługuje następujące sklepy:
- Morele
- x-kom

Oczywiście będę dodawał więcej sklepów... z czasem, ale ty też możesz to zrobić!

# Jak się tego używa?
Po prostu wklejasz linki produktów które cię interesują do pliku `linki.txt` i uruchamiasz program.

![Plik linki.txt](https://i.ibb.co/wsDYTVh/howto.png) 

Program co kilka sekund będzie sprawdzał czy któryś z tych komponentów jest dostępny i będzie cię o tym informował.

![enter image description here](https://i.ibb.co/t4S5dVD/howto2.png)

# Konfiguracja emaila
Musisz posiadać konto mailowe (polecam gmaila) oraz zezwolić na mniej bezpieczne aplikacje
![link](https://myaccount.google.com/lesssecureapps?pli=1&rapt=AEjHL4OWumQQ0Kl4UkZ-zYIvAh7YK87JzIAe8tNNVg_Ibsa_U-srgtTOtr4RLqioRgKJJauK-wO-iCctvh-nPV7J24xFqjAXaQ)

Edytujesz plik `configmail.txt` w następujący sposób:

```
true
hasło do konta gmail
email BEZ DOMENY
domena np @gmail.com
email docelowy
port serwera smtp
adres serwera smtp
```


Konfiguracja dla gmaila

```
true
password
test
@gmail.com
hejka@gmail.com
587
smtp.gmail.com
```

TODO:

 - [ ] Więcej sklepów
 - [x] Informacja mailowa o dostępnym produkcie
 - [ ] Proxy (nie wiem czy to będzie potrzebne)
