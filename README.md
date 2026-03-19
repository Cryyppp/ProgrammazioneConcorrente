# Programmazione Concorrente — App WPF

Un'applicazione Windows Presentation Foundation (WPF) in C# che replica il sito web sulla programmazione concorrente con design Terminal Academica.

## 📋 Contenuti

L'app include 6 capitoli completi:

1. **Introduzione** — Panoramica generale sulla programmazione concorrente
2. **Semafori** — Binari, contatori, Dijkstra, mutua esclusione
3. **Produttore-Consumatore** — Bounded-Buffer Problem con simulazione interattiva
4. **Problemi Classici** — Lettori-Scrittori, Dining Philosophers
5. **Soluzioni** — Monitor, variabili di condizione, best practices
6. **Rischi & Patologie** — Deadlock, race conditions, starvation

## 🎨 Design

- **Dark Mode**: Tema Terminal Academica con sfondo quasi-nero (#0d0f1a)
- **Colori**: Verde terminale (#00ff88), ambra (#ffb347), rosso (#ff5555)
- **Font**: JetBrains Mono per titoli e codice, IBM Plex Sans per corpo del testo
- **Sidebar**: Navigazione fissa con capitoli selezionabili
- **Responsive**: Layout adattivo per diverse risoluzioni

## 🚀 Requisiti

- **Windows 7 o superiore** (per WPF)
- **.NET 8.0 SDK** o superiore
- **Visual Studio 2022** (Community Edition è sufficiente)

## 📦 Compilazione

### Opzione 1: Visual Studio

1. Apri Visual Studio 2022
2. Seleziona "Apri un progetto o una soluzione"
3. Naviga alla cartella `ConcurrentProgrammingWPF` e seleziona il file `.csproj`
4. Premi `Ctrl+Shift+B` per compilare
5. Premi `F5` per eseguire

### Opzione 2: Riga di comando

```bash
cd ConcurrentProgrammingWPF
dotnet build
dotnet run
```

## 📁 Struttura del Progetto

```
ConcurrentProgrammingWPF/
├── ConcurrentProgrammingApp.csproj    # File di progetto
├── App.xaml                            # Risorse globali e stili
├── App.xaml.cs                         # Logica dell'app
├── MainWindow.xaml                     # Finestra principale con sidebar
├── MainWindow.xaml.cs                  # Logica di navigazione
├── Views/
│   ├── HomeView.xaml                   # Pagina iniziale
│   ├── HomeView.xaml.cs
│   ├── SemaforiView.xaml               # Capitolo 1
│   ├── SemaforiView.xaml.cs
│   ├── ProduttoreConsumerView.xaml     # Capitolo 2 (con simulazione)
│   ├── ProduttoreConsumerView.xaml.cs
│   ├── ProblemiClassiciView.xaml       # Capitolo 3
│   ├── ProblemiClassiciView.xaml.cs
│   ├── SoluzioniView.xaml              # Capitolo 4
│   ├── SoluzioniView.xaml.cs
│   ├── RischiView.xaml                 # Capitolo 5
│   └── RischiView.xaml.cs
└── README.md                           # Questo file
```

## ✨ Funzionalità

### Navigazione
- Sidebar con elenco di tutti i capitoli
- Selezione capitolo con evidenziazione
- Scroll automatico dei contenuti

### Simulazione Interattiva (Produttore-Consumatore)
- **Play/Pausa**: Controlla l'esecuzione della simulazione
- **Reset**: Ripristina lo stato iniziale
- **Visualizzazione Buffer**: Mostra gli elementi nel buffer in tempo reale
- **Valori Semafori**: Visualizza i valori di mutex, empty, full
- **Log**: Traccia le operazioni di produttore e consumatore

### Contenuti
- Definizioni e concetti fondamentali
- Diagrammi e tabelle comparativi
- Esempi di codice pseudocodice
- Best practices e soluzioni

## 🎯 Utilizzo

1. **Avvia l'app** — Doppio clic su `ConcurrentProgrammingApp.exe` (dopo la compilazione)
2. **Seleziona un capitolo** — Clicca su un elemento nella sidebar
3. **Leggi il contenuto** — Scorri il contenuto principale
4. **Interagisci con la simulazione** — Nel capitolo Produttore-Consumatore, usa i pulsanti Play/Pausa/Reset

## 🔧 Personalizzazione

### Cambiare i colori
Modifica i valori RGB in `App.xaml`:
```xml
<Color x:Key="PrimaryColor">#00ff88</Color>
<Color x:Key="AmberColor">#ffb347</Color>
```

### Aggiungere nuovi capitoli
1. Crea un nuovo file `NuovoCapitoloView.xaml` in `Views/`
2. Aggiungi il corrispondente file `.xaml.cs`
3. Aggiungi un elemento alla ListBox in `MainWindow.xaml`
4. Aggiungi un case nello switch di `MainWindow.xaml.cs`

## 📝 Note Tecniche

- **XAML**: Markup dichiarativo per l'interfaccia utente
- **C#**: Logica dell'applicazione e gestione degli eventi
- **WPF**: Framework per applicazioni desktop Windows
- **Threading**: La simulazione usa `Task` e `CancellationToken` per operazioni asincrone

## 🐛 Troubleshooting

### "dotnet: command not found"
Installa .NET SDK da https://dotnet.microsoft.com/download

### L'app non si avvia
Assicurati di avere Windows 7 o superiore e .NET 8.0 SDK installato

### La simulazione non funziona
Prova a premere il pulsante Reset e poi Play

## 📄 Licenza

Questo progetto è fornito come materiale didattico sulla programmazione concorrente.

## 🔗 Correlati

- Sito web: https://concurrents-itzorus2.manus.space
- Documento originale: Document(1)(1).docx

---

**Versione**: 1.0.0  
**Data**: 2025  
**Autore**: Manus AI
