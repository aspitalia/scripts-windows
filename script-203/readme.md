# Script 203

Quando si sta lavorando ad un'applicazione esistente, o a maggior ragione su una nuova, è importante dare un aspetto grafico accattivante e quanto più possibile coerente con tutto il resto dell'ecosistema. Se si ha a che fare con un gestionale o con un qualsiasi sistema in cui c'è da tenere traccia di un elenco di persone, senza troppi sforzi si può riutilizzare il componente che Windows stesso mette a disposizione tramite l'app dei contatti, per avere un look and feel similare: il controllo XAML **PersonPicture**, infatti, ha già una sua logica integrata per mostrare le iniziali della persona, il suo nome, o la sua immagine di profilo, in base ai valori che vengono passati.

```
<Grid>
    <PersonPicture
        DisplayName="Mario Rossi"
        ProfilePicture="Assets\mariorossi.png"
        Initials="MR" />
</Grid>
```

Poiché può essere mostrato solo un valore alla volta, è presente un meccanismo di priorità per definire quale valore mostrare: viene data la precedenza all'immagine di profilo, poiché più accattivante, mentre, qualora non ci fosse, vengono mostrati *DisplayName* e *Initials* (le iniziali), di conseguenza. 

Il risultato finale sarà simile al seguente:
[img]

Per ottenere l'effetto illustrato nell'immagine però, è necessario aggiungere una relativa *TextBlock* affiancata al controllo *PersonPicture*, poiché il controllo stesso non si occupa della gestione del nome completo e il layout integrale dipende comunque dall'applicazione stessa.

Qualora ci fossero già dei contatti in memoria, perché magari si sta lavorando ad un'applicazione che gestisce una rubrica telefonica, ad esempio, si può anche mettere l'oggetto *Contact* in binding:

```
<PersonPicture Contact="{x:Bind MyContact, Mode=OneWay}" />
```
