# Script 200

Una delle limitazioni imposte dalla Universal Windows Platform è che, grazie alla sandbox e agli standard di sicurezza messi a disposizione dalla piattaforma, non è possibile accedere a contenuti che si trovano in posizioni diverse dalle cartella Documenti, Foto e Video. Con l'ultimo update di Windows 10, è stata aggiunta una nuova capability, chiamata *broadFileSystemAccess* che serve proprio ad ovviare a questo problema e permette la scrittura in una parte qualsiasi del filesystem a cui l'utente stesso che sta eseguendo l'applicazione ha accesso.

Per aggiungere questa capability, è necessario aggiungere anche il namespace dedicato all'interno del file *Package.appxmanifest*:

```
xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
IgnorableNamespaces="uap mp rescap"

<!--  -->

<Capabilities>
  <rescap:Capability Name="broadFileSystemAccess" />
</Capabilities>
```

Come si può notare, però, questo nuovo namespace fa parte delle **restricted capability**: qualora l'applicazione venga distribuita tramite lo store, verrà eseguito un ulteriore passaggio di analisi prima della pubblicazione e verrà richiesto il motivo per la quale l'applicazione richiede questo particolare accesso e quali benefici porterà agli utenti.

Una volta configurato il file di manifest, si può richiedere l'accesso ad un qualsiasi percorso di sistema (tenendo cura dei permessi di accesso) ed elencare, come dimostra l'esempio seguente, tutti i file presenti nelle cartelle (ed eventuali sotto-cartelle):

```
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
    await GetFiles(@"C:\Users\aspitalia\Desktop");
}

private async Task GetFiles(string path)
{
    if (string.IsNullOrEmpty(path))
        return;

    try
    {
        var folder = await StorageFolder.GetFolderFromPathAsync(path);
        var folders = await folder.GetFoldersAsync();

        foreach (StorageFolder directory in folders)
        {
            var files = await directory.GetFilesAsync();

            foreach (StorageFile file in files)
            {
                Debug.WriteLine($"Found {file.Name} in {directory.Name}");
            }
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}
```

Le API messe a disposizione dal framework sono identiche a quelle già utilizzate in precedenza per accedere, ad esempio, alla cartella Documenti, pertanto non è necessario andare a personalizzare eventuale codice pre-esistente. 

Il codice sorgente di questo script è disponibile su GitHub al seguente indirizzo https://github.com/aspitalia/scripts-windows/tree/master/script-200