# Script 198

Tra le novità introdotte da Windows 10 versione 1803 (conosciuto come Redstone 4) vi è la possibilità di aggiungere metadati al controllo **RichEditBox**.
Il modo più rapido per aggiungere questi metadati è utilizzare il prefisso "@" prima di una parola. Comportamento utilizzato da Facebook e Twitter per taggare le persone in un post.

L'aggiunta di questi metadati avviene mediante la classe **ContentLink**, quest'ultima è a tutti gli effetti di informazioni "pescate" da un provider.
I provider rivestono un ruolo fondamentale in quanto, come detto, forniscono le informazioni, visualizzate durante la digitazione. Out-of-the-box Windows fornisce due provider: *ContactContentLinkProvider* e *PlaceContentLinkProvider*, rispettivamente per fornire una lista di contatti o di luoghi.

```
<RichEditBox VerticalAlignment="Top" Margin="20">
    <RichEditBox.ContentLinkProviders>
        <ContentLinkProviderCollection>
            <ContactContentLinkProvider/>
        </ContentLinkProviderCollection>
    </RichEditBox.ContentLinkProviders>
</RichEditBox>
```

Il codice precedente imposta il *ContenProvider* utilizzato dalla nostra *RichTextEdit* per mostrare una lista di contatti (presi dalla rubrica) che corrispondono al criterio di ricerca specificato dopo il carattere "@".

![Tagging tramite ContactContentLinkProvider](https://preview.ibb.co/k8xyqo/198.png)

Il codice sorgente di questo script è disponibile su GitHub al seguente indirizzo https://github.com/aspitalia/scripts-windows/tree/master/script-198.