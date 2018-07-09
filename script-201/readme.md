# Script 201

Con l'ultima versione di Windows 10 è ora possibile eseguire più di un'istanza di un'app UWP.

Per prima cosa è necessario installare il *Multi-Instance App Project Templates.vsix*, disponibile nel [marketplace di Visual Studio](https://marketplace.visualstudio.com/).
Terminata l'installazione, sarà disponibile un nuovo template: troveremo, dopo la creazione di un nuovo progetto sulla base di questo template, nel file *package.appxmanifest*, la proprietà *SupportsMultipleInstances* valorizzata a *true*.

```
<Package
  xmlns:desktop4="http://schemas.microsoft.com/appx/manifest/desktop/windows10/4"
  xmlns:iot2="http://schemas.microsoft.com/appx/manifest/iot/windows10/2"  
  IgnorableNamespaces="uap mp desktop4 iot2">
  <Applications>
    <Application Id="App"
desktop4:SupportsMultipleInstances="true"
iot2:SupportsMultipleInstances="true">
    </Application>
  </Applications>
</Package>
```

Inoltre, il template aggiunge un file *Program.cs* che ci permette, ad esempio, a fronte di una richiesta di attivazione, di determinare se l'applicazione è già in esecuzione e eventualmente decidere l'operazione da compiere. Immaginate, ad esempio, che la richiesta di attivazione arrivi da un doppio click di un file che magari è già aperto: in questo caso quello che volete fare potrebbe essere diverso da aprire una nuova istanza.