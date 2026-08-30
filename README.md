# PDF-Umbenennen

Windows-Desktopprogramm zum **sicheren Umbenennen von PDF-Dateien** mit integrierter Vorschau.

Ordner wählen, Datei in der Liste anklicken, Inhalt prüfen, neuen Namen vergeben — fertig. Das Original bleibt während der Vorschau unangetastet.

## Funktionen

- Verzeichnis mit PDF-Dateien auswählen (ohne Unterordner)
- Letztes Verzeichnis wird beim nächsten Start wieder geöffnet, sofern es noch existiert
- Vorschau im DevExpress-PDF-Viewer (scrollen, zoomen)
- Skalierung: **auf Breite**, **auf Höhe**, **Ganze Seite**
- Umbenennen per `File.Move` — das Original wird nie gelöscht
- Die Vorschau arbeitet mit einer **Temp-Kopie**, damit der Viewer die Originaldatei nicht sperrt

## Voraussetzungen

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [DevExpress WinForms PDF Viewer](https://www.nuget.org/packages/DevExpress.Win.PdfViewer/) (NuGet: `DevExpress.Win.PdfViewer` 26.1.4)  
  Zum Entwickeln und Ausführen ist eine gültige DevExpress-Lizenz oder eine Evaluation nötig.

## Bauen

```powershell
dotnet build PDF-Umbenennen.slnx
```

Die Anwendung selbst mit `dotnet run` bzw. über Visual Studio starten.

## Bedienung

1. **Verzeichnis wählen** — alle `*.pdf` im Ordner erscheinen in der Liste.
2. Eine Datei anklicken — die Vorschau lädt eine Kopie unter `%TEMP%\PDF-Umbenennen\`.
3. Bei Bedarf zoomen (**auf Breite** / **auf Höhe** / **Ganze Seite**).
4. Den gewünschten Namen in der Textbox eintragen (mit oder ohne `.pdf`).
5. **Umbenennen** — existiert der Zielname schon oder schlägt das Umbenennen fehl, bleibt das Original unverändert.

## Technik

| | |
| --- | --- |
| UI | WinForms |
| Zielframework | `net10.0-windows` |
| Solution | `PDF-Umbenennen.slnx` |
| PDF-Anzeige | DevExpress `PdfViewer` |
| Letztes Verzeichnis | `%LocalAppData%\PDF-Umbenennen\last-folder.txt` |

## Hinweise

Der DevExpress-PDF-Viewer unterliegt den [DevExpress-Lizenzbedingungen](https://www.devexpress.com) und darf ohne passende Lizenz nicht weitergegeben werden.
