# Reflektion — Slutprojekt

**Namn:** Filippa van der Kolk

**Kurs:** Grundläggande OOP i C#

**Projekt:** The Vampire Castle (Dungeon Crawler)

**Datum:** 2 Oktober 2026


---

## Vad var svårast att lösa?

Det svåraste att lösa tyckte jag var att få alla klasser att samarbeta utan att tappa bort sig i logiken. Jag fastnade flera gånger i hur rummen skulle kopplas ihop, hur NPC-systemet skulle fungera och hur input-hanteringen skulle byggas så att spelet inte kraschade vid fel input. Det tog längre tid än jag trodde att förstå hur Game-klassen skulle styra allt, men jag kom vidare genom att bryta ner problemet i mindre delar och testa funktionerna separat. När jag väl insåg hur Player, Room och Vampire hängde ihop blev allt mycket tydligare.

---

## Hur fungerade samarbetet i gruppen?

Samarbetet fungerade väldigt bra! Vi hade regelnbunda möten och pratade nästan alltid via Discord där vi tog gemensamma beslut om struktur, funktioner och spelide. Kodningen i sig skedde främst i Olivers Visual Studio (+ skärmdelning via Discord) men vi satt tillsammans och diskuterade varje del innan vi skrev den. Jag la själv främst till saker via GitHub genom att lägga till .md-filer, bilder och visuella ideer med hjälp av Copilot. Vi jobbade inte med branches och pull requests på ett avancerat sätt, utan mer som ett gemensamt utvecklingsflöde där vi hela tiden kommunicerade och tog beslut ihop.

---

## Om du fick göra om det — vad hade du gjort annorlunda?

Tänk på din lösning, din struktur, eller hur ni jobbade. Vad skulle du ändra?

---

## Valfritt — arv och datastrukturer

Om ni använde arv: varför valde ni den strukturen? Vilken `List<T>` (eller annan datastruktur) använde ni, och varför just den?

---

## VG — Motivering

Fyll i det här avsnittet om du siktar på VG. Lämna tomt = G-bedömning.

Svara på frågorna som hör till ditt projekt och dina VG-val. Radera resten.

### Skogsäventyret

- Vilken datastruktur valde ni för vapensortimentet och varför?
- Hur sorterade ni monstren i arenan?
- Hade ni kunnat lösa arenan utan arv?

### Havsforskarna

- Vilken VG-utbyggnad valde ni och varför just den?
- Vad är den tekniskt svåraste delen av er lösning?
- Hade ni kunnat lösa det utan `List<T>`?

### Dungeon Crawler

- Vilka VG-utbyggnader valde ni och varför?
- Motivera era datastrukturval (`string` som nyckel, `List<string>` för dialog, valt sparformat).
- Vad hade en annan struktur gett er?
