# SnakeGame – Konsolowa gra w węża

Prosta implementacja klasycznej gry Snake w C# działająca w konsoli.

## Cel gry

Zbierać jak najwięcej gwiazdek `*` (pokarm),  
unikając zderzenia ze ścianami i własnym ogonem.

Każde zjedzenie:
- +1 punkt
- wąż rośnie o 1 segment
- pojawia się nowy pokarm w losowym miejscu

## Sterowanie

| Klawisz       | Kierunek   |
|---------------|------------|
| ↑   / W       | góra       |
| ↓   / S       | dół        |
| ←   / A       | lewo       |
| →   / D       | prawo      |

Nie można zawrócić o 180° (np. z prawej od razu w lewo).

Gra kończy się po:
- uderzeniu w ścianę
- zderzeniu z własnym ciałem

## Jak uruchomić

### Sposób 1 – najprostszy (bez kompilacji do .exe)

# w folderze z projektem (tam gdzie jest Program.cs)
```
dotnet run
```

### Sposób 2 – samodzielny plik wykonywalny (zalecany do udostępniania)

# Windows (64-bit)
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

# Linux (64-bit)
```
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

# macOS (Intel)
```
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```

# macOS (Apple Silicon M1/M2/M3)
```
dotnet publish -c Release -r osx-arm64 --self-contained true -p:PublishSingleFile=true
```

Po wykonaniu polecenia plik wykonywalny znajdziesz w:
`textbin/Release/net8.0/[twoja-platforma]/publish/
np. ObstakelSnake.exe (Windows) lub ObstakelSnake (Linux/macOS)`
Struktura projektu
```
├── Program.cs       ← główna logika gry, pętla, rysowanie, kolizje
├── Pixel.cs         ← klasa reprezentująca punkt (głowa / segment)
└── Obstakel.cs      ← klasa reprezentująca pokarm
```

## Postęp prac i zmiany w projekcie

### Naprawione błędy i zaimplementowane funkcjonalności

- **#1** Zmiana języka gry na angielski  
  Gra została w pełni przetłumaczona na język angielski – teraz dostępna dla szerszego grona odbiorców.

- **#3** Refaktoryzacja modelu danych (klasa Obstacle)  
  Przebudowa klasy przeszkód – kod jest czytelniejszy, bardziej modularny i łatwiejszy w dalszym rozwoju.

- **#5** Płynne sterowanie i obsługa klawiatury  
  Wprowadzono płynne poruszanie się węża (bez zacinania się przy szybkich zmianach kierunku) oraz niezawodną obsługę klawiatury.

- **#6** Logika ogona i rośnięcia węża  
  Poprawiono mechanikę wydłużania ogona po zjedzeniu pokarmu – teraz działa idealnie, bez błędów wizualnych i logicznych.

- **#8** System kolizji i punktacji  
  Zaimplementowano niezawodne wykrywanie kolizji (ze ścianami, własnym ogonem i przeszkodami) oraz system punktacji z aktualizacją w czasie rzeczywistym.

- **#9** Interfejs użytkownika i czyszczenie kodu  
  Odświeżono UI (wyświetlanie punktów, komunikatów o końcu gry itp.) oraz gruntowne posprzątanie kodu – mniej duplikacji, lepsza czytelność.

## Najważniejsze scalone zmiany (merged pull requesty)

- **#15** readme added  
  Dodano i uzupełniono plik README.md – projekt zyskał czytelną dokumentację startową.

- **#13** Feature/UI refactor  
  Duży refactor interfejsu użytkownika i powiązanych mechanik – poprawiona czytelność kodu, lepsza organizacja komponentów UI, usunięto zbędne zależności.

- **#12** Usunięto błędny powtarzający się kod  
  Wyeliminowano duplikację kodu – czystsza baza, mniejsze ryzyko błędów przy przyszłych zmianach.

- **#11** Zaimplementowano poprawną detekcję kolizji ze ścianami i ogonem węża  
  Naprawiono i ujednolicono system wykrywania kolizji – gra kończy się teraz prawidłowo w każdej sytuacji.

- **#10** Zaimplementowano poprawną detekcję kolizji ze ścianami i ogonem węża (poprzednia wersja)  
  Wcześniejsza iteracja poprawki kolizji – scalona jako krok pośredni.

- **#7** Wprowadzenie nieblokującego odczytu klawiszy i płynnego ruchu  
  Przerobiono sterowanie na model nieblokujący → wąż porusza się płynnie nawet przy bardzo szybkich zmianach kierunku.

- **#4** Dodano YPos  
  Wprowadzono poprawne zarządzanie współrzędną Y (prawdopodobnie w kontekście pozycji obiektów / siatki gry).

- **#2** Fix/fix language  
  Poprawki językowe – ujednolicenie tekstów, usunięcie błędów tłumaczeniowych, pełna angielska wersja gry.
