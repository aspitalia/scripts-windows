# Script 197

Ci sono diversi casi in cui un'applicazione potrebbe avere senso di esistere anche senza l'interfaccia grafica, tra cui:

* le utility che richiedono un semplice input dall'utente per eseguire operazioni automatiche in background;
* sistemi headless, specialmente nel mondo dell'IoT, in cui i sistemi sono completamente autonomi.

Per creare un'applicazione console però, si è sempre ricorsi all'uso di Win32 anziché della Universal Windows Platform poiché è mancato il supporto per tutta la parte relativa ai namespace *System.Console* e al multi-instancing (che approfondiremo in uno script successivamente). Con l'introduzione del nuovo Windows 10 April Update e del relativo SDK 17134 è finalmente possibile realizzare proprio un'app di questo tipo, andando a modificare manualmente il file di manifest, come mostrato nell'esempio seguente:

```
<Extensions>
    <uap5:Extension Category="windows.appExecutionAlias" Executable="Script197.exe" EntryPoint="Script197.App">
        <uap5:AppExecutionAlias desktop4:Subsystem="console" iot2:Subsystem="console">
            <uap5:ExecutionAlias Alias="Script197.exe" />
        </uap5:AppExecutionAlias>
    </uap5:Extension>
</Extensions>
```

All'interno del nodo *Application* del file di manifest è stata aggiunta l'estensione *windows.appExecutionAlias* che permette di specificare la tipologia di subsystem che deve essere utilizzato, ovvero *console*. Come si può notare, questa registrazione è stata fatta per due specifici ambienti, desktop ed IoT, perché sono le uniche due SKU attualmente supportate e che permettono l'esecuzione della shell. I due namespace sono registrati come segue:

```
<Package ... 
    xmlns:uap5="http://schemas.microsoft.com/appx/manifest/uap/windows10/5" 
    xmlns:desktop4="http://schemas.microsoft.com/appx/manifest/desktop/windows10/4" 
    xmlns:iot2="http://schemas.microsoft.com/appx/manifest/iot/windows10/2" 
    IgnorableNamespaces="uap mp desktop4 iot2">
```

Una volta definito il subsystem, è necessario andare ad eliminare tutto l'entrypoint definito dall'*App.xaml* ed eventuali altre pagine che contengono XAML/UI, poiché infatti non è possibile avere due entrypoint diversi, oppure lanciare dalla shell anche la relativa interfaccia grafica. A questo punto si può creare un sistema di accesso all'applicazione tramite la classe *Program* ed il metodo *Main*:

```
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nella UWP console app!");
        Console.ReadKey();
    }
}
```

Una volta creata e deployata l'applicazione, è possibile invocarla direttamente dal prompt dei comandi (oppure da PowerShell) tramite il suo nome ma, poiché si tratta di un'app UWP, è anche possibile vederla registrata all'interno del menù start oppure distribuirla tramite il Windows Store.

![Prompt dei comandi](https://preview.ibb.co/geq9Vo/197.png)

Il codice sorgente di questo script è disponibile su GitHub al seguente indirizzo https://github.com/aspitalia/scripts-windows/tree/master/script-197.
