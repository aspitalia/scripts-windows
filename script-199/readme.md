# Script 199

Quando durante il giorno facciamo uso di applicazioni su telefono, tablet e PC, diamo per scontato alcuni concetti fondamentali, come, ad esempio, il fatto che le applicazioni ragionino sempre attorno a noi stessi, mostrandoci i dati che abbiamo salvato in esecuzioni precedenti, piuttosto che creandoci un'interfaccia personalizzata secondo i nostri gusti. Esistono scenari in cui c'è bisogno però di avviare un'applicazione con più utenti in contemporanea, tra cui la classica collaborazione su un documento, piuttosto che un gioco che fa uso del multiplayer.

Per abilitare questo scenario è necessario avere un sistema che sia in grado di creare questo contesto e di gestirlo in maniera trasparente per noi e questo è fattibile tramite la classe *UserPicker* che permette di selezionare gli utenti. E' possibile verificare che la funzionalità sia supportata sul device tramite la chiamata ad *IsSupported*, quindi si può chiamare la *PickSingleUserAsync* che creerà l'interfaccia grafica per permettere all'utente di scegliere quale account utilizzare:

```
if (UserPicker.IsSupported())
{
    var picker = new UserPicker
    {
        AllowGuestAccounts = true
    };

    var user = await picker.PickSingleUserAsync();
    var profileImage = await user.GetPictureAsync(UserPictureSize.Size424x424);
}
```

L'utente ritornato rappresenta un oggetto di tipo *User* che ha sicuramente effettuato il login (poiché sono abilitati anche gli utenti Guest, è sempre la UI che si occupa di gestire anche la form di login) ed è associato ad un oggetto di tipo *IGameController*, ovvero il gamepad che ha effettuato la scelta. Una volta ottenuto l'utente sarà possibile recuperare, ad esempio, la sua immagine di profilo oppure altre proprietà ad esso correlate.

Parlando dei device invece, non tutte le categorie sono in grado di supportare questa funzionalità: su mobile non è possibile avere più di un account e per cambiarlo è necessario fare il reset, mentre su PC bisognerebbe fare il logout ed entrare in Windows con un nuovo utente, per questo, come si poteva intuire dal paragrafo precedente, al momento questa funzionalità è supportata solo da Xbox.  
Poiché le applicazioni della Universal Windows Platform sono in grado di funzionare su tutte le categorie di device, ma considerando che la collaborazione non si può avere su tutti i device, è bene restringere il funzionamento dell'applicazione stessa a livello di *Package.appxmanifest*:

```
<Dependencies>
    <TargetDeviceFamily Name="Windows.Xbox" MinVersion="10.0.0.0" MaxVersionTested="10.0.0.0" />
</Dependencies>
```

Inoltre, siccome il multi-user è uno scenario previsto out-of-the-box, va abilitato in modo esplicito all'interno delle property del file di manifest:

```
<uap:SupportedUsers>multiple</uap:SupportedUsers>
```

Il codice sorgente di questo script è disponibile su GitHub al seguente indirizzo https://github.com/aspitalia/scripts-windows/tree/master/script-199