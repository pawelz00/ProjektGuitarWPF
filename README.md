# Programowanie obiektowe - projekt

Prosta aplikacja do zarządzania gitarzystami oraz gitarami. Każda gitara posiada swojego producenta, typ oraz rodzaj strun. Gitarzysta może ale nie musi posiadać gitarę.

Technologie: WPF/XAML, Entity Framework.

Aplikacja działa na bazie danych LocalDb (MsSqlServer).

Tworzenie bazy danych: Menedżer pakietów -> update-database

Możliwość dodawania gitar, producentów, gitarzystów.
Możliwość usuwania gitar, producentów, gitarzystów.
Możliwość wyświetlenia producentów (pojedynczo) oraz gitar i gitarzystów (lista).
Możliwość aktualizacji gitar (update).

Dodawanie gitarzysty bez gitary -> ID gitary = 0 (zero)

Dodawanie, usuwanie oraz update posiadają prostą walidację danych.

---

## Dostępni producenci, typy oraz rodzaje strun (domyślnie):
![photo](https://github.com/pawelz00/ProjektGuitarWPF/blob/master/entities.png?raw=true)