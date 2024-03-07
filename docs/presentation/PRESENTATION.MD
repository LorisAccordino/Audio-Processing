# Esplorando le Funzioni Sinusoidali nel Mondo del Suono e della Tecnologia

Oggi intraprenderemo un avvincente viaggio attraverso il mondo delle funzioni sinusoidali, scoprendo come queste non solo si manifestino in matematica, ma trovino anche applicazioni concrete nel suono e nella musica. La nostra avventura ci guiderà attraverso esperimenti intriganti, connettendo la teoria matematica alle telecomunicazioni e all'elettronica.

# Fondamenti della Musica

La musica è l'arte dell'organizzazione del suono. Il suono è la sensazione data dalla vibrazione di un corpo in oscillazione. Le onde generate dalle vibrazioni di una sorgente sonora sono percepite dal nostro udito e formano la base della musica.

## Hertz (Hz) e Frequenze

La frequenza è la grandezza fisica che esprime il numero di cicli o oscillazioni di un fenomeno periodico che si verificano in un secondo. In termini più semplici, la frequenza misura il numero di ripetizioni di un evento oscillatorio in un secondo. La formula che esprime la relazione tra frequenza ($f$) e periodo ($T$) è la seguente:

$$
f = {1 \over T}
$$

Dove:

- $f$ rappresenta la frequenza,
- $T$ rappresenta il periodo, cioè la durata di un singolo ciclo.

L'unità di misura della frequenza è l'Hertz (Hz):

$$
1 Hz = {1 \over s} = {s^{-1}}
$$

Ad esempio, se abbiamo un suono con una frequenza di 440 Hz, significa che si verificano 440 cicli sonori al secondo. Le frequenze basse sono percepite come toni gravi, mentre le frequenze alte sono percepite come toni acuti. La nostra mente interpreta queste variazioni di frequenza come variazioni nella tonalità del suono, contribuendo alla ricchezza e alla complessità della nostra percezione uditiva.

## Propagazione del Suono

Il suono è una forma di energia che si propaga attraverso l'aria o altri mezzi elastici sotto forma di onde di pressione. In generale, il processo di propagazione del suono coinvolge la trasmissione di impulsi di pressione attraverso le molecole dell'aria.

### Emettitori e Ricevitori Sonori:

- **Altoparlante (Speaker):** Quando un altoparlante emette suono, la membrana dell'altoparlante vibra, creando variazioni di pressione nell'aria circostante. Queste variazioni si propagano in onde sonore che si diffondono nello spazio circostante.

- **Microfono:** Viceversa, quando un microfono riceve suono, la membrana del microfono è sensibile alle variazioni di pressione nell'aria. Queste variazioni causano vibrazioni nella membrana del microfono, che vengono quindi convertite in segnali elettrici.

### Percezione Uditiva:

- **Orecchio:** Il nostro udito è sensibile a queste variazioni di pressione nell'aria. L'orecchio umano è in grado di percepire le variazioni di pressione causate dalle onde sonore. Quando queste onde raggiungono l'orecchio, il timpano vibra in risposta alle variazioni di pressione. Queste vibrazioni vengono poi trasmesse attraverso una serie di ossicini nell'orecchio medio e convertite in segnali neurali che il cervello interpreta come suono.

## Armoniche e Forma d'Onda

Per cogliere appieno la complessità del suono, consideriamo il concetto di armoniche. Le armoniche rappresentano le diverse componenti di frequenza presenti in un suono e giocano un ruolo cruciale nella definizione della sua forma d'onda. Tuttavia, osservare la forma d'onda da sola non ci consente di identificare e suddividere le specifiche frequenze in gioco. Questo sarà oggetto di analisi più approfondite tramite strumenti come l'FFT (Trasformata di Fourier Rapida) e l'analisi spettrale.

### Armoniche e Componenti di Frequenza:
Le armoniche sono multipli interi della frequenza fondamentale di un suono. Ad esempio, se la frequenza fondamentale è $f$, le armoniche includono $2f$, $3f$, $4f$, $…$ . Ognuna di queste armoniche contribuisce con la propria intensità e caratteristica al suono complessivo.

### Forma d'Onda come Somma di Armoniche:
Le funzioni sinusoidali sono ampiamente utilizzate per rappresentare matematicamente le armoniche. Ogni sinusoide corrisponde a una singola frequenza, e la combinazione (somma) di diverse onde sinusoidali genera la forma d'onda complessiva. In questo modo, la matematica delle funzioni sinusoidali diventa uno strumento potente per scomporre e comprendere la ricchezza spettrale di un suono.

### Limitazioni della Forma d'Onda:
Nonostante la forma d'onda offra una visione intuitiva della struttura temporale del suono, non fornisce dettagli sulle singole frequenze coinvolte. Per analizzare e identificare con precisione queste frequenze, ci rivolgeremo all'uso di strumenti più avanzati, come l'FFT e l'analisi spettrale.

In sintesi, esplorare le armoniche e la forma d'onda di un suono ci offre una prospettiva essenziale per comprendere la sua struttura spettrale e la sua identità timbrica. Tuttavia, per una suddivisione accurata delle frequenze, faremo affidamento su strumenti analitici specifici, che approfondiremo successivamente nel nostro percorso. Le funzioni sinusoidali, insieme alle armoniche che generano, costituiscono comunque un fondamentale strumento matematico per analizzare e rappresentare la complessità dei suoni che ci circondano.

## Il Diapason e l'Accordatura
Il diapason emette un suono puro - cioè un'unica onda sinusoidale, priva di armoniche - fisso di 440Hz, che funge da riferimento per l'accordatura. Questa frequenza diventa il punto di partenza per assicurare che le altre note suonate sugli strumenti siano in armonia tra loro.

### Complessità dell'Accordatura:
Identificare quale frequenza specifica sta suonando, con un accordatore elettronico, non è affatto banale, poiché ogni audio presenta una forma d'onda che contiene diverse frequenze e armoniche e non solo una determinata frequenza. Non possiamo semplicemente "ascoltare" la frequenza come faremmo con una nota singola di un diapason. Invece, utilizziamo strumenti avanzati come la Trasformata di Fourier Rapida (FFT) per analizzare la struttura spettrale complessa dell'audio. Questo ci permette di scomporre l'onda in componenti sinusoidali, rivelando le diverse frequenze in gioco e facilitando un'accordatura precisa.

# Fondamenti dell'Audio

L'audio è una rappresentazione dell'energia sonora sotto forma di onde acustiche. Queste onde sono generate da vibrazioni di una sorgente sonora, come uno strumento musicale o una voce umana. L'audio può essere registrato e riprodotto attraverso vari dispositivi elettronici.

## Differenza tra Audio Analogico e Digitale:
L'audio analogico rappresenta il suono in maniera continua nel tempo, mentre l'audio digitale lo rappresenta mediante un insieme discreto di campioni. L'audio digitale offre vantaggi in termini di manipolazione e memorizzazione, poiché i dati sono rappresentati da una sequenza di valori discreti.

## Campionamento e Sample Rate:
Il campionamento è il processo chiave nella trasformazione di un segnale analogico in formato digitale. Si tratta di misurare l'ampiezza del segnale a intervalli regolari nel tempo, noti come campioni. Il sample rate rappresenta il numero di campioni raccolti in un secondo ed è misurato in Hertz (Hz). Ad esempio, un sample rate di 44100 Hz significa che vengono raccolti 44100 campioni al secondo.

## Formato WAV e Codifica PCM a 16 bit:
Il formato WAV è un formato di file audio diffusamente utilizzato che conserva dati audio in forma non compressa. La sua struttura si basa sulla codifica PCM (Pulse Code Modulation) a 16 bit, dove ogni campione audio riceve un valore numerico. Questo valore numerico rappresenta in modo preciso l'ampiezza del segnale audio in quel determinato punto temporale. In sintesi, ogni valore numerico corrisponde a un'istantanea della forma d'onda e consente la manipolazione digitale dell'audio.

## Volume in dB e Scala Logaritmica
Il volume dell'audio è spesso espresso in decibel (dB), utilizzando una scala logaritmica. Questo approccio tiene conto della percezione umana del suono, poiché percepiamo i cambiamenti di volume in modo non lineare. La scala dei decibel si basa sulla relazione tra la potenza del segnale sonoro, il volume di default di un impianto senza distorsione e il livello attuale del volume.

Nel contesto dell'audio, il riferimento di 0 dB è associato al volume di default di un impianto, che rappresenta il livello di volume senza alcuna distorsione. Valori inferiori a 0 dB indicano generalmente una riduzione del volume rispetto al livello di riferimento, mentre valori superiori indicano un amplificazione.

Per comprendere meglio la relazione logaritmica, consideriamo il rapporto di potenze in dB:

$$ 
dB = 10 \log_{10}\left(\frac{W1}{W2}\right) = 10 \log_{10}\left(\frac{V1}{V2}\right)^2 = 20 \log_{10}\left(\frac{V1}{V2}\right) 
$$

In un contesto analogico, potremmo fare riferimento a un segnale di 0 dB come all'assenza di amplificazione o attenuazione. Nel digitale, dove i segnali possono essere rappresentati con precisione numerica, il concetto di dB può anche riflettere la quantità di amplificazione o attenuazione applicata a un segnale.

Per esempio:

- Un segnale a -6 dB indica che il livello di potenza è la metà rispetto al volume di default, corrispondendo a un calo di volume percepito.

- Un segnale a +6 dB indica che il livello di potenza è il doppio rispetto al volume di default, corrispondendo a un aumento di volume percepito.

In pratica, la scala logaritmica dei decibel consente di rappresentare in modo efficace variazioni di volume relativamente piccole, adattandosi bene alla nostra percezione non lineare del suono.

# Esplorazione Pratica:
Utilizzando Audio Processing, esploreremo la forma d'onda di un file audio WAV. Questo ci darà una visione visiva della rappresentazione digitale del suono, evidenziando come le variazioni nell'ampiezza siano catturate dai campioni. Inoltre, sperimentando con equalizzazione, variazioni di pitch, velocità e tempo, vedremo come queste manipolazioni influenzano la forma d'onda e, di conseguenza, il suono che ascoltiamo.

Questa introduzione alle basi dell'audio digitale ci fornirà una solida base per comprendere come le funzioni sinusoidali e le trasformazioni matematiche si integrino nel nostro viaggio attraverso il suono e la tecnologia.

## Forma d'Onda e Canali Audio

Il file WAV supporta canali audio sinistro (L) e destro (R), che corrispondono rispettivamente a left (sinistra) e right (destra) nei sistemi stereo. Nel programma Audio Processing, abbiamo implementato la visualizzazione stereo e la visualizzazione per entrambi i canali della waveform, offrendo una panoramica dettagliata delle caratteristiche sonore di ciascun canale.

### Waveform Stereo
La visualizzazione della waveform stereo riflette l'andamento combinato dei canali, fornendo informazioni sulla percezione spaziale del suono. Analizzeremo come le variazioni tra i canali creano effetti di panning, contribuendo alla nostra esperienza uditiva.

### Canali Separati (Mono)
Oltre alla waveform stereo, esamineremo anche le forme d'onda separate per ciascun canale: left (sinistra) e right (destra). Questa analisi consentirà di identificare caratteristiche specifiche di ciascun canale e di esplorare dettagliatamente il contenuto sonoro di ogni componente. Sarà un passo cruciale nel comprendere la struttura e la distribuzione del suono nei sistemi stereo.

Questa dettagliata esplorazione delle waveform stereo e mono nel nostro programma ci preparerà per ulteriori manipolazioni audio, aprendo prospettive intriganti nel nostro viaggio attraverso il suono e la tecnologia.

### Controllo del Panning nei Canali Separati

All'interno del nostro programma, non solo analizzeremo le forme d'onda separate per ciascun canale (left e right), ma avremo anche la possibilità di controllare il pan (panning). Il panning ci consente di distribuire il segnale audio tra i due canali, determinando la posizione spaziale del suono. Questo controllo aggiuntivo apre la porta a un'esperienza uditiva dinamica, consentendoci di commutare il segnale verso un determinato canale o al centro, creando effetti sonori unici e ampliando le possibilità creative nella manipolazione del suono.

## Manipolazione delle Onde Sinusoidali

### Cambiamento di Volume (Ampiezza) e Trasformazioni della Forma d'Onda
Un aumento dell'ampiezza $A$ comporterà un aumento del volume percepito, mentre una diminuzione avrà l'effetto opposto. Per monitorare visivamente questi cambiamenti, il nostro programma implementa un Vu Meter. Questo strumento simula il funzionamento analogico, utilizzando una scala logaritmica in decibel $(dB)$ per rappresentare il livello del volume. Osservando il Vu Meter, potremo percepire e analizzare il comportamento del suono in maniera intuitiva e precisa.

Quando consideriamo l'ampiezza $A$ nell'ambito delle onde sinusoidali e del cambiamento di volume, possiamo interpretare $A$ come un moltiplicatore per l'intera forma d'onda. Se $A$ è uguale a 1, la forma d'onda mantiene la sua ampiezza originale. Se $A$ è maggiore di 1, stiamo amplificando la forma d'onda, aumentandone il volume. Se $A$ è inferiore a 1, stiamo attenuando la forma d'onda, diminuendone il volume.

Per passare da $A$ (ampiezza lineare della forma d'onda) a $dB$ (volume percepito), possiamo utilizzara la seguente formula:

$$
dB = 20 \log_{10}(A)
$$

Questa formula ci permette di calcolare i dB a partire dall'ampiezza $(A)$. Tuttavia, è importante notare che una rappresentazione di ampiezza oltre 1 $(A > 1)$ può portare a un aumento del volume con possibile distorsione (clipping) audio. Nel dominio digitale, ciò si traduce nel "ritaglio" (clipping) dei valori al di fuori dell'immagine della funzione sinusoidale $[-1,+1]$. Questo troncamento può causare una riproduzione distorta della forma d'onda, mentre a livello analogico (come nella riproduzione tramite casse), il clipping si manifesta come una distorsione vera e propria, alterando significativamente la qualità del suono con conseguente riproduzione distorta e rovinata.

Queste formule ci aiuteranno a comprendere in modo chiaro e matematico come le trasformazioni delle onde sinusoidali e della forma d'onda influenzino il suono che ascoltiamo.



### Cambiamento di Pitch
Esploreremo come il cambiamento di pitch, ossia la variazione della frequenza delle onde sinusoidali, influisca sul carattere tonale del suono. In termini teorici, modificare il pitch richiederebbe la moltiplicazione della frequenza di ogni componente sinusoidale per un fattore di pitch. Tuttavia, nella pratica, l'operazione richiede tecniche più avanzate, come l'uso della FFT (Fast Fourier Transform) per scomporre l'onda e successivamente rielaborare il segnale con la frequenza desiderata.

In linea teorica, avendo già a disposizione (per esempio tramite FFT) tutte le componenti sinusoidali della forma d'onda, per applicare un cambiamento di pitch $(P)$ a un segnale audio, possiamo rappresentare la trasformazione dell'onda sinusoidale di frequenza $f$ come segue:

$$
\sin(f) → \sin(f \cdot P)
$$

Dove:

- $f$ è la frequenza originale dell'onda sinusoidale,
- $P$ è il coefficiente di pitch.

Se consideriamo un'onda complessa con più componenti sinusoidali, la formula generale per applicare il pitch a tutte le componenti sarebbe una somma:

$$
\sum_{i=1}^{n}  \sin(P \cdot f_i)
$$

Oppure, più semplicemente:

$$ 
\sin(f_1 \cdot P) + \sin(f_2 \cdot P) + … + \sin(f_n \cdot P) $$

Dove $f_i$ rappresenta le frequenze delle diverse componenti sinusoidali presenti nel segnale originale.

Tuttavia, come accennato precedentemente, implementare questa trasformazione richiede una conoscenza più approfondita del contenuto spettrale del segnale e spesso coinvolge l'uso di algoritmi più avanzati come la Trasformata di Fourier Rapida (FFT).

Il pitch, associato comunemente alla percezione dell'acuto o del grave, diventa quindi un elemento interessante da esplorare nel nostro viaggio attraverso il suono e la sua manipolazione digitale.

### Cambiamento di Velocità
La modifica della velocità di riproduzione, implica una variazione del sample rate. Questo influisce sulla velocità di riproduzione, ma anche sul pitch. In altre parole, quando si modifica la velocità di riproduzione di un brano, è come se stessimo accelerando o rallentando la riproduzione di un vinile. Se aumentiamo la velocità, il brano suona più veloce, ma contemporaneamente l'intonazione (pitch) si alza, rendendo il suono più acuto. Analogamente, se rallentiamo la velocità, il brano suona più lentamente, ma l'intonazione si abbassa, rendendo il suono più grave.

Questo fenomeno è simile a ciò che accade quando si modifica la velocità di riproduzione di un disco. Quando il disco gira più velocemente, il pitch della musica aumenta, mentre rallentando il disco, il pitch diminuisce. Quindi, la relazione tra velocità e pitch è intrinseca nella manipolazione della velocità di riproduzione audio.

### Cambiamento di Tempo
Se desideriamo velocizzare o rallentare un brano senza alterarne il pitch, dobbiamo applicare un coefficiente di pitch che sia l'inverso del fattore di velocità di riproduzione desiderato. Questo significa che se vogliamo raddoppiare la velocità di riproduzione, dovremmo applicare un coefficiente di pitch di 0.5, mentre se vogliamo dimezzare la velocità, il coefficiente di pitch sarà 2.

La formula per calcolare il pitch $(P)$ in funzione del coefficiente di velocità di riproduzione $(V)$ è la seguente:

$$ 
P = {1 \over V} = V^{-1}
$$

Quindi, se vogliamo mantenere costante il pitch mentre cambiamo la velocità, dobbiamo regolare il pitch in modo inversamente proporzionale alla velocità desiderata, in modo da compensare il cambio di tonalità causato dalla variazione del sample rate. Questo ci consentirà di ottenere l'effetto desiderato di velocizzazione o rallentamento senza alterare l'intonazione del suono.

## Equalizzazione
La rappresentazione spettrale di una forma d'onda ci consente di suddividere il suono in diverse fasce di frequenza, aprendo la strada all'equalizzazione (EQ). L'equalizzazione è una tecnica che manipola l'ampiezza di specifiche bande di frequenza per alterare la timbrica del suono. Questo processo è essenziale per adattare e ottimizzare l'ascolto in base alle preferenze personali o alle esigenze di una particolare registrazione.

Le trasformazioni attraverso le bande di frequenza, come i toni bassi (low), medi (mid), e alti (high), sono fondamentali per modellare il profilo sonoro.

### Filtri e Trasformazioni Frequenziali
I filtri sono dispositivi essenziali nell'elaborazione del segnale audio, poiché consentono il controllo selettivo delle frequenze. Esistono diversi tipi di filtri, ciascuno progettato per modificare specifiche caratteristiche dello spettro sonoro. Vediamo alcune categorie principali:

- **Passa Basso:** Favorisce le frequenze più basse, attenuando quelle più alte. È come se lasciasse passare le basse frequenze, da cui il nome "passa basso".

- **Passa Alto:** Fa il contrario del passa basso, consentendo il passaggio delle frequenze più alte e attenuando quelle più basse.

- **Passa Banda:** Permette solo il passaggio di un intervallo specifico di frequenze, attenuando sia quelle più basse che quelle più alte.

- **Reiezione di Banda:** Fa il contrario del passa banda, attenuando solo un intervallo specifico di frequenze e lasciando passare le altre.

Questi filtri sono fondamentali per modellare il suono, e la loro applicazione pratica coinvolge l'utilizzo di algoritmi e tecniche di elaborazione del segnale per ottenere gli effetti desiderati. Sono una componente chiave nella creazione di equalizzatori e nella manipolazione delle caratteristiche timbriche del suono.

## Analisi spettrale con FFT
La Trasformata di Fourier Rapida (FFT) è un algoritmo che consente di scomporre un segnale nel dominio della frequenza. In termini semplici, ci permette di analizzare un segnale audio e individuare le diverse componenti spettrali che lo compongono.

La formula della FFT è complessa, ma in termini generali, essa trasforma un segnale dal dominio del tempo a quello della frequenza. Ecco la rappresentazione matematica di una delle sue più semplici (ma meno performanti) implementazioni:

$$ 
X(k) = \sum_{n=0}^{N-1} x(n) \cdot e^{-i {2 \pi \over N} kn}
$$

Dove:

- $\displaystyle X(k)$ 
rappresenta l'ampiezza della componente di frequenza $k$,
- $\displaystyle  x(n)$ 
è il campione del segnale nel dominio del tempo all'istante $n$,
- $e$ è il numero di Nepero (base del logaritmo naturale),
- $i$ è l'unità immaginaria,
- $N$ è il numero totale di campioni nel segnale.

In pratica, la FFT suddivide il segnale in una serie di componenti sinusoidali di diverse frequenze, permettendoci di visualizzare il contenuto spettrale del segnale. Questo è particolarmente utile nell'analisi audio, poiché ci consente di identificare le frequenze predominanti, le armoniche e altri dettagli importanti della struttura sonora.

Durante l'utilizzo di Audio Processing, esploreremo come applicare la FFT per ottenere informazioni dettagliate sulla struttura spettrale di una registrazione audio.

## Accordatura con Tuner e FFT
All'interno di Audio Processing, abbiamo implementato un accordatore (tuner) che sfrutta l'analisi spettrale mediante la Trasformata di Fourier Rapida (FFT). L'accordatore è progettato per identificare la frequenza fondamentale di un segnale audio, consentendo così di determinare se uno strumento musicale è correttamente accordato.

Il funzionamento dell'accordatore si basa su una suddivisione delle componenti spettrali del segnale in diverse frequenze. Applicando la FFT, otteniamo una serie di funzioni sinusoidali, ognuna caratterizzata da una specifica frequenza e ampiezza. L'accordatore analizza queste componenti e individua la frequenza con l'ampiezza maggiore, identificandola come la frequenza fondamentale.

In termini pratici, se stai accordando uno strumento, l'accordatore analizzerà il suono prodotto e indicherà quale frequenza stai effettivamente suonando. Questo consente di regolare l'accordatura dello strumento in modo preciso e accurato.

## Oltre la Musica: la vastità degli Segnali Analogici
Nel vasto campo dell'audio analogico, l'audio in sé è solo uno dei molti tipi di segnali con cui si può interagire. Gli strumenti come un oscilloscopio ci permettono di catturare e analizzare qualsiasi onda elettromagnetica o segnale, aprendo la porta a un mondo di possibilità oltre alla musica.

Immagina di toccare un cavo poco schermato, o il cui segnale è addirittura amplificato, collegato a un dispositivo audio, o, più genericamente, un oscilloscopio. In questo caso, potremmo fare da antenna per varie frequenze, in base alla "lunghezza d'onda" del nostro corpo. Un esempio affascinante di questo fenomeno è rappresentato dai disturbi a 50Hz provenienti dalla corrente alternata della bassa tensione (corrente degli impianti di ambito domestico). Se tocchiamo per terra con un jack, possiamo percepire chiaramente l'onda pura a 50Hz, dimostrando come il nostro corpo possa agire da antenna per diverse frequenze.

Questi esperimenti ci svelano un lato affascinante dell'audio e dei segnali, mostrandoci che la musica è solo una parte di un universo più ampio che abbraccia elettronica, telecomunicazioni e tutte le sfaccettature connesse all'analisi e alla manipolazione dei segnali. L'audio analogico, dunque, si rivela come un campo ricco di connessioni tra la teoria elettronica e le applicazioni pratiche, dove la musica è solo uno dei tanti modi per esplorare la vastità di questo mondo intrigante.

# Conclusione
In chiusura, abbiamo esplorato la vastità delle funzioni sinusoidali, passando dai concetti matematici alla loro applicazione pratica nel mondo del suono e della tecnologia. Spero che questa presentazione abbia aperto nuove prospettive e ispirato ulteriori esplorazioni in questo affascinante campo.