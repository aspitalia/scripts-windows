# Script 204

Nello script di settimana scorsa, abbiamo visto come si può integrare nella Universal Windows Platform un controllo nativo per quanto riguarda il supporto ai contatti, in modo da poter mostrare, con una logica centrale e coerente con quanto esposto dal sistema operativo stesso, alcuni dati relativi a delle persone.

Il controllo XAML *PersonPicture*, oltre a quanto già visto, consente anche di assegnare all'utente una serie di "badge", ovvero una specie di placeholder che ne indicano lo stato, come ad esempio lo stato "occupato" di Skype quando siamo in una conferenza telefonica, piuttosto che l'appartenenza ad un team specifico all'interno di una organizzazione.

```
<Grid>
    <PersonPicture
        BadgeText="Mario Rossi"
        BadgeImageSource="Assets\red-circle-png"
        BadgeGlyph="&#xE778;"
        BadgeNumber="2"
        ProfilePicture="Assets\profile-picture.png" />
</Grid>
```

Nel caso mostrato nel codice qui sopra, oltre all'immagine del profilo per illustrare la persona di cui si vuole dare contesto, sono stati aggiunti anche quattro badge di diverso tipo: il *BadgeText* è solo una proprietà testuale, il *BadgeNumber* invece è rappresentato da un numero intero e può essere utile per indicare il numero di notifiche/messaggi ricevuti da quella determinata persona, piuttosto che *BadgeImageSource* che può essere utilizzato per mostrare una immagine contenuta nelle risorse dell'applicazione (in questo caso un pallino rosso per indicare lo stato "occupato") e, infine, il *BadgeGlyph* che può essere uno qualsiasi dei simboli contenuti nel font Segoe MDL2 di Microsoft. 

Esattamente come già visto per le altre proprietà del controllo *PersonPicture*, anche per i badge ci sono diverse priorità poiché non potranno essere mostrati tutti assieme e, di default, l'immagine ha sempre la meglio. Il risultato finale dipenderà dalle impostazioni scelte, ma sarà simile al seguente:

[img]