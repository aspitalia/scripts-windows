# Script 205

Tra le gravi mancanze di Windows 10 da sempre, buona parte della "colpa" è sicuramente da attribuire allo stack grafico, in quanto è risaputo e abbiamo visto più volte nel corso di questi script, che lo XAML della Universal Windows Platform non è allineato (e probabilmente mai lo sarà) al 100% con, ad esempio, lo XAML esposto in WPF. 

Fino all'arrivo del Windows 10 Creators Update (15063) non era ad esempio possibile nemmeno impostare la sottolineatura sulle caselle di testo, oppure impostare il testo barrato, che richiedeva l'implementazione di almeno altri due controlli (come ad esempio una *Grid/Canvas* per disegnare la lineetta della sottolineatura e un contenitore per allineare il tutto con il controllo *TextBlock*). Ad oggi, però, grazie alla proprietà *TextDecorations* è tutto più semplice, come si può vedere dal codice seguente:

```
<StackPanel Orientation="Horizontal">

    <TextBlock Text="Underline" TextDecorations="Underline" />
    <TextBlock Text="Strikethrough" TextDecorations="Strikethrough" />

</StackPanel>
```

L'effetto ottenuto, sarà simile al seguente:
[img]

Ora, non solo è possibile applicare questi effetti, ma è possibile anche scegliere la tipologia di sottolineatura, impostabile tramite la proprietà *UnderlineType* a valori come *Dash* (la classica linea tratteggiata), *Dotted* (una linea a puntini) o combinazioni delle due, con linee singole e doppie.