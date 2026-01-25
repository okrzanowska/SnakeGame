# SnakeGameMarkdown# Obstakel Snake – Konsolowa gra w węża

Prosta implementacja klasycznej gry Snake w C# działająca w terminalu/konsoli.

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

```bash
# w folderze z projektem (tam gdzie jest Program.cs)
dotnet run
Sposób 2 – samodzielny plik wykonywalny (zalecany do udostępniania)
Bash# Windows (64-bit)
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# Linux (64-bit)
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true

# macOS (Intel)
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true

# macOS (Apple Silicon M1/M2/M3)
dotnet publish -c Release -r osx-arm64 --self-contained true -p:PublishSingleFile=true
Po wykonaniu polecenia plik wykonywalny znajdziesz w:
textbin/Release/net8.0/[twoja-platforma]/publish/
np. ObstakelSnake.exe (Windows) lub ObstakelSnake (Linux/macOS)
Struktura projektu
text.
├── Program.cs       ← główna logika gry, pętla, rysowanie, kolizje
├── Pixel.cs         ← klasa reprezentująca punkt (głowa / segment)
└── Obstakel.cs      ← klasa reprezentująca pokarm 
Aktualny stan projektu

Bardzo podstawowa wersja
Brak menu, pauzy, zapisu wyniku
Brak poziomów trudności
Ruch w pionie jest co drugi tick wolniejszy (żeby nie było za szybko)
Plansza dostosowuje się do rozmiaru okna (min 20×10, max 80×30)

Co można poprawić (TODO)


Dodać menu startowe
Dodać pauzę (np. klawisz P / Spacja)
Dodać licznik punktów na ekranie w trakcie gry
Dodać zapisywanie najlepszego wyniku
Poprawić płynność ruchu (usunąć spowolnienie w pionie)
Dodać dźwięki (Console.Beep)
Dodać kolory dla różnych poziomów / bonusów