# Script 202

In uno degli ultimi script abbiamo visto come utilizzare il *RichEditBox* per creare un sistema di tag in stile Facebook. Questi "tag" sono interattivi e il sistema associa il programma predefinito in base al tipo di contenuto visualizzato. Ad esempio, se si usa il **ContactContentLinkProvider**, alla pressione del "tag", il sistema operativo aprirà l'applicazione associata alla gestione dei contatti. Questo comportamento è facilmente modificabile creando un event handler per l'evento *ContentLinkInvoked*.

```
<RichEditBox VerticalAlignment="Top" Margin="20" ContentLinkInvoked="editor_ContentLinkInvoked">
    <RichEditBox.ContentLinkProviders>
        <ContentLinkProviderCollection>
            <ContactContentLinkProvider/>
        </ContentLinkProviderCollection>
    </RichEditBox.ContentLinkProviders>
</RichEditBox>
```

L'evento verrà gestito all'interno del code-behind:

```
private void editor_ContentLinkInvoked(RichEditBox sender, ContentLinkInvokedEventArgs args)
{
    if (args.ContentLinkInfo.LinkContentKind == "People")
    {
        args.Handled = true;
        //todo aprire l'applicazione preferita
    }
}
```