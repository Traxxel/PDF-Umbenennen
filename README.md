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
- DevExpress-Lizenzschlüssel lokal bzw. auf der Build-Maschine (siehe unten)

## Bauen

```powershell
dotnet build PDF-Umbenennen.slnx
```

Die Anwendung selbst mit `dotnet run` bzw. über Visual Studio starten.

## Download (GitHub Actions)

Die Pipeline baut eine **self-contained** Windows-x64-Version (`.NET` ist in der ZIP, Nutzer brauchen kein SDK).

1. Im Repo: **Settings → Secrets and variables → Actions → New repository secret**
2. Name: `DevExpress_License`  
   Wert: Inhalt von `DevExpress_License.txt` (Download Manager, nicht ins Git).
3. Jeder Push auf `main` legt unter **Actions** ein Artefakt `PDF-Umbenennen-win-x64` ab.
4. Ein **Release zum Herunterladen**: Tag anlegen, z. B. `git tag v1.0.0` und `git push origin v1.0.0`. Die ZIP erscheint unter **Releases**.

Ohne Secret schlägt der Build fehl (gewollt). Trial-Keys erzeugen Wasserzeichen — für öffentliche Releases eine gekaufte Lizenz verwenden.

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

## DevExpress-Lizenz

Der PDF-Viewer unterliegt der [DevExpress-EULA](https://www.devexpress.com/support/eulas/). Kurz, nach der [offiziellen Doku](https://docs.devexpress.com/GeneralInformation/405494):

- **Entwicklung und Build** brauchen einen gültigen Schlüssel (gekaufte Lizenz oder 30-Tage-Trial), z. B. `%AppData%\DevExpress\DevExpress_License.txt`. Den Key **nicht** ins Git-Repo und **nicht** in die ausgelieferte App legen. Endanwender brauchen ihn nicht.
- **Mit gekaufter Lizenz** (WinForms / DXperience / Universal, je nach Abo): Runtime-DLLs dürfen **zusammen mit der EXE** an Nutzer gehen. Design-Time-Assemblies (`*.Design.dll`) nicht.
- **Nur Trial / kein Key:** Compiler-Warnung **DX1000** („cannot be deployed to end-users“) bzw. **DX1001** (Key fehlt). Zusätzlich Wasserzeichen/Trial-Balken zur Laufzeit — auch für Nutzer. Trial-Builds nicht als Release veröffentlichen.

Details: [License Key](https://docs.devexpress.com/GeneralInformation/405494), [Trial vs. Licensed](https://docs.devexpress.com/GeneralInformation/403579), [Assembly Deployment](https://docs.devexpress.com/GeneralInformation/17237).
