# CompanyProjectManagement
Solution of the test task - Application for company project management
Komentár k riešeniu zadania

Riešenie zadania pozostáva z troch hlavný vrstiev. Je tu rezentačná grafická vrstva s code behind, ktorý slúži na komunikáciu s logickou
vrstvou a obsluhu prezentačnej vrstvy. Potom nasleduje logická vrstva, ktorá obsahuje základnú logiku hlavných objektov aplikácie. 
A dátová vrstva, ktorá predstavuje ukladanie nastavení a dát v aplikácii do samostatných xml súborov. Za týmto účelom si aplikácia 
vytvára vlastný adresár v priečinku AppData konkrétneho užívateľa, na ktorého počítači je aplikácia spustená. Všetky xml súbory sa potom 
ukladajú v tomto priečinku SpravaProjektovFirmy. Takáto architektúra s menšími zmenami umožňuje aj napojenie na iné dátove rozhranie
(iný typ súbor, databáza, atď.).

Doba riešenia zadania bola 13 hodín čím bohužiaľ dosť výrazne presiahla lehotu 8 hodín. Uvedený časový údaj sa vzťahuje 
len na čistú pŕacu (písanie kódu, premyšĺanie nad riešením rôznych problémov, diagnostika a oprava chýb). Počas prestávok (wc, strava,
oddych, odreagovanie sa) a okomentovania kódu som čas práce nemeral. 

Dôvodom presiahnútia povoleného časového limitu bolo, že som sa často zdržal hlavne pri diagnostike a oprave chýb, ktoré neboli priamo
zrejmé a bolo nutné ich pohľadať a vyriešiť ich opravu. Podstatný čas navyše mi zabralo riešenie rôzných špecifických požiadavok vo WPF
s ktorými ešte ako začiatočník nemám veľa skúseností. Preto mi trochu trvalo, kým sa mi podarilo nájsť alebo vymyslieť dostatočne 
uspokojivé riešenie. Ako príklad uvádzam funkciu editácie záznamov v listboxe: 

Samozrejme som chcel, aby sa po ukončení editácie vybraného projektu zmeny okamžite prejavili v listboxe. Pokúšal som sa o to 
najskôr prostredníctvom implementácie rozhrania INotifyPropertyChanged a píslušnej události v triede správcu projektov pre zmenu objektu
projektu. Bohužiaľ bezvýsledne a vzhľadom na časové obmedzenie som musel toto elegantnejšie riešenie nahradiť menej elegantným tak,
že pri zmene vlastností objektu je objekt vymazaný a na jeho miesto je pridaný objekt s novými vlastnosťami, zatiaľ čo jeho ID a poloha
v listboxe sa zachováva. 

Na riešenie zadania bolo použité vývojové prostredie Microsoft Visual Studio Professional 2019, verzia 16.2.0. S iným vývojovým prostredím
dosiaľ skúsenosti nemám (okrem prostredia IDLE, kde som pracoval s jazykom Python). Oceňujem na ňom však prehľadný vzhľad, prívetivé
uživateľské prostredie a predovšetkým nástroj IntelliSense, ktorý predstavuje neoceniteľného pomocníka hlavne zaćiatoćníkom, 
no práve tak aj pokročilejším vývojárom.

Dúfam, že sa mi mojím rieśením podarilo čo najviac priblížiť Vaším predstavám o správnom riešení. 
