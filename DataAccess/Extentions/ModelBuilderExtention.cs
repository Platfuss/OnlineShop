using DataAccess.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extentions;

public static class ModelBuilderExtention
{
    public static void Configure(this ModelBuilder builder)
    {
        var customerAddress = builder.Entity<CustomerAddress>();
        customerAddress.HasKey(ca => new { ca.AddressId, ca.CustomerId });
        customerAddress.HasOne(ca => ca.Address).WithMany(a => a.CustomerAddress).HasForeignKey(ca => ca.AddressId);
        customerAddress.HasOne(ca => ca.Customer).WithMany(c => c.CustomerAddress).HasForeignKey(ca => ca.CustomerId);

        var orders = builder.Entity<Order>();
        orders.HasOne(o => o.InvoiceAddress).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        orders.HasOne(o => o.ShippingAddress).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);

        var orderDetails = builder.Entity<OrderDetail>();
        orderDetails.HasIndex(od => new { od.OrderId, od.ItemId }).IsUnique();

        var users = builder.Entity<User>();
        users.HasOne(u => u.Customer).WithOne(c => c.User).IsRequired();
        users.HasIndex(u => u.Email).IsUnique();

        var carts = builder.Entity<Cart>();
        carts.HasIndex(c => new { c.CustomerId, c.ItemId }).IsUnique();


        builder.Entity<Item>()
            .HasData(
                new Item() { Id = 1, Name = "Twilight Imperium", Price = 1000M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Recommended = true, Description = "Mecatol Rex. Centrum znanej galaktyki i niegdysiejsza siedziba Imperium Lazax. Dzisiaj Rex to tylko zgliszcza potężnej cywilizacji, dawno zapomniane imperium, a także obiekt pożądania wszystkich ras biorących udział w galaktycznych konfliktach." },
                new Item() { Id = 2, Name = "7 Cudów świata", Price = 158M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Recommended = true, Description = "Zostań przywódcą jednego z siedmiu wielkich miast świata antycznego. Zbieraj surowce ze swoich ziem, weź udział w odwiecznym wyścigu cywilizacyjnym, nawiąż kontakty handlowe i stwórz militarną potęgę. Pozostaw ślad na kartach historii budując cud architektury, który przetrwa wieki! 7 cudów świata to świetnie zbalansowana gra o rozwoju cywilizacji, która łączy proste zasady i dynamiczną rozgrywkę z planowaniem i strategicznym myśleniem. Uczestnicy wcielają się w przywódców starożytnych miast, które starają się poprowadzić do jak najbardziej optymalnego rozwoju. " },
                new Item() { Id = 3, Name = "Brass: Birmingham", Price = 328M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Description = "Masz ochotę na wzięcie udziału w nowej erze Rewolucji Przemysłowej, w realiach jednej z najlepszych gier ekonomicznych wszech czasów? Brass: Birmingham, sequel wydanego w 2007 roku Brassa, to powtórna wycieczka do epoki, w której zmysł strategicznego myślenia napędzany intuicją ekonomiczną potrafił kreślić życiorysy na miarę Friedricha Kruppa i Stanisława Wokulskiego. Czy zdołasz pójść w ślady wielkich przemysłowców z epoki 80-godzinnego tygodnia pracy? Udowodnij, że jesteś graczem z prawdziwego zdarzenia!" },
                new Item() { Id = 4, Name = "Brzdęk! W! Kosmosie!: Raban w próżni", Price = 165M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Description = "Obrzydliwie zły Lord Eradikatus opanował niemal całą galaktykę. W tej chwili wizytuje jej podbite sektory na pokładzie Eradykatora – swego flagowego statku. Jak przystało na tyrana, pyszni się przy tym niesamowicie. Najwyższa pora utrzeć mu nieco nosa. Wraz z innymi złodziejaszkami postanawiasz odciążyć dyktatora ze zbędnych bogactw. Prosta sprawa, wystarczy przedostać się do modułu dowodzenia, zgarnąć, co się da i znikać, ile sił w nogach." },
                new Item() { Id = 5, Name = "Colt Express", Price = 111M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Recommended = true, Description = "Czy bandytom uda się zachować zimną krew i uniknąć świstających dookoła kul? Czy zdołają wykraść pieniądze przeznaczone na wypłaty dla pracowników Kompanii Węglowej Nice Valley? Czy przechytrzą dzielnego szeryfa, Samuela Forda? Bądź tym, który na koniec gry zostanie najbogatszym członkiem gangu." },
                new Item() { Id = 6, Name = "Everdell", Price = 196M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Description = "W uroczej dolinie Everdell, pod gałęziami wysokich drzew, wśród omszałych głazów, rozwija się cywilizacja leśnych zwierząt. Wiele lat minęło od jej początków i wreszcie nadszedł czas, by odkryć nowe tereny i zakładać zupełnie nowe miasta. Gdy zasiądziesz do gry, wcielisz się w lidera grupy stworzeń, które wyruszą na podbój nieznanego. Trzeba będzie zbudować wiele budynków, poznać nowe stworzenia i dać się ponieść nadchodzącym wydarzeniom. To będzie pracowity rok!" },
                new Item() { Id = 7, Name = "Inis", Price = 218M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Description = "W Inis wykorzystacie trzy rodzaje kart. Karty Akcji dobieracie w fazie Zgromadzenia i używacie ich, żeby rekrutować klany lub budować cytadele oraz miejsca kultu. Karty Przewagi przypadają tym, którzy kontrolują określone tereny i pozwalają np. przemieścić klan lub uniknąć ataku. Z czasem zdobędziecie też karty eposu. Każda z nich odnosi się bezpośrednio do celtyckiej mitologii. Oko Balora, Morrígan, Szał bitewny, Ostrzeżenie Cathbada, Przybytek Cernunnosa, Opowieść o Cúchulainie oraz wiele innych spowodują, że wasze klany będą zdolne do bohaterskich czynów, co w konsekwencji pomoże wam pokonać przeciwników." },
                new Item() { Id = 8, Name = "Jamajka", Price = 134M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Recommended = true, Description = "W 1678 roku Henry Morgan, korsarz z wieloletnim stażem, został mianowany gubernatorem Jamajki. Powierzono mu zadanie wypędzenia piratów i rozbójników morskich. On jednak, zamiast wypełnić misję, zaprosił swoich wspólników i towarzyszy broni, by osiedlili się na wyspie i w spokoju cieszyli się łupami. W 30. rocznicę tego wydarzenia został zorganizowany Wielki Wyścig, podczas którego najznamienitsze pirackie statki i załogi rywalizują o to, który z nich wróci jako najbogatszy." },
                new Item() { Id = 9, Name = "Nemesis", Price = 500M, Amount = 100, Category = "Gry planszowe", AddedToShop = DateTime.Now, Description = "Nagle wybudzasz się z hibernacji. Gdy powoli odzyskujesz świadomość i kontrolę nad własnym ciałem, przypominasz sobie, że jesteś na statku kosmicznym \"Nemesis\". Podróżujesz na Ziemię z górniczej planety Dantis umiejscowionej w systemie planetarnym Trappist-1. Zaskoczony i zaniepokojony zdajesz sobie sprawę, że komputer wybudził Cię w trybie awaryjnym tuż przed ostatnim nadprzestrzennym w kierunku Ziemi. Zaniepokojony, stanem statku i załogi, żądasz od komputera pokładowego więcej informacji. Na odpowiedź czekasz zdecydowanie zbyt długo, ale w końcu dane zaczynają napływać. Nie wiesz nic odnośnie statku, a stan całej załogi wydaje się być w porządku... całej, poza jedną osobą. Serce natychmiast skacze Ci do gardła..." },
                new Item() { Id = 10, Name = "Wojownicy Podziemi: Druga edycja", Price = 137M, Amount = 0, Category = "Gry planszowe", AddedToShop = DateTime.Now.AddMinutes(5), Recommended = true, Description = "W świecie, którym nie ma prawdziwych bohaterów, są prawdziwe kłopoty. Ale też ogromne możliwości! Nie ważne, czy na co dzień sprzątasz w królewskim wychodku, czy parasz się kontrolą biletów. I Ty możesz zostać bohaterem – przepatrywać podziemia, patroszyć potwory, przejmować ich pieniąchy i wreszcie pluskać się w przepychu i prestiżu. Oczywiście z większym prawdopodobieństwem zginiesz, ale kto nie ryzykuje…, ten nie zostaje WOJOWNIKIEM PODZIEMI." },
                new Item() { Id = 11, Name = "Midnights (Moonstone Blue Edition)", Price = 79.99M, Amount = 100, Category = "Muzyka", AddedToShop = DateTime.Now, Description = "Dziesiąty studyjny album Taylor Swift – „Midnights”. To kolekcja muzyki napisanej w środku nocy, podróż poprzez strachy i słodkie sny. Chodząc po domu i mierząc się z demonami – historie trzynastu nieprzespanych nocy, które wydarzyły się w życiu Taylor." },
                new Item() { Id = 12, Name = "Red (Taylor’s Version)", Price = 88.99M, Amount = 100, Category = "Muzyka", AddedToShop = DateTime.Now, Recommended = true, Description = "„Red (Taylor's Version)” to nagrana na nowo wersja albumu „Red” z 2012 roku. Fani po raz pierwszy otrzymają wszystkie 30 piosenek, które miały trafić na płytę, nawet tę, która trwa 10 minut." },
                new Item() { Id = 13, Name = "Evermore", Price = 52.99M, Amount = 100, Category = "Muzyka", AddedToShop = DateTime.Now, Description = "Taylor Swift wydała drugi album-niespodziankę w 2020 roku. „Evermore” to kontynuacja leśnego, romantycznego klimatu na „Folklore”." },
                new Item() { Id = 14, Name = "Fearless (Taylor's Version)", Price = 89.99M, Amount = 100, Category = "Muzyka", AddedToShop = DateTime.Now, Recommended = true, Description = "Taylor Swift spełnia obietnicę i nagrywa na nowo swój katalog. Na nową wersję albumu „Fearless” trafi aż 6 niepublikowanych wcześniej utworów, które powstały, gdy Taylor miała 16-18 lat." },
                new Item() { Id = 15, Name = "Malinowa chmurka", Price = 31M, Amount = 100, Category = "Ciasta", AddedToShop = DateTime.Now, Description = "Nasz bestseller! Delikatny, śmietankowy biszkopt, okryty warstwą delikatnej bitej śmietany, przełożony malinowym musem, wykończony warstwą chrupiącej bezy obsypanej prażonymi migdałami" },
                new Item() { Id = 16, Name = "Sernik domowy", Price = 25M, Amount = 100, Category = "Ciasta", AddedToShop = DateTime.Now, Description = "Poczuj smak dzieciństwa. Tradycyjny, babciny, śmietankowy sernik z zanurzonymi we wnętrzu rodzynkami." },
                new Item() { Id = 17, Name = "Ciasto Szwarcwaldzkie", Price = 30M, Amount = 100, Category = "Ciasta", AddedToShop = DateTime.Now, Recommended = true, Description = "Puszysty, czekoladowy biszkopt przełożony warstwą delikatnej bitej śmietany oraz wiśniami zatopionymi w galaretce o tym samym smaku, udekorowany śmietaną oraz uroczymi, czekoladowymi serduszkami" },
                new Item() { Id = 18, Name = "Ciasto Afrykańczyk", Price = 37M, Amount = 100, Category = "Ciasta", AddedToShop = DateTime.Now, Description = "Nasz bestseller! 3 blaty aromatycznego miodowego ciasta, przełożone masą na bazie gotowanego sera oblane rozpływającą się w ustach czekoladą" },
                new Item() { Id = 19, Name = "Cukierki Michałki klasyczne Wawel – 1kg", Price = 37.9M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Pyszne Michałki Klasyczne firmy Wawel. Cukierki z orzeszkami arachidowymi w czekoladzie pakowane po 1kg. Sprzedaż tylko na całe opakowania. Termin ważności minimum 3 miesiące od zakupu. Przy większych zakupach lub z kilku aukcji za wysyłkę płacisz tylko raz." },
                new Item() { Id = 20, Name = "Cukierki Mieszanka Krakowska Wawel – 1kg", Price = 37.9M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Pyszna Mieszanka Krakowska firmy Wawel. Cukierki – owocowe galaretki w czekoladzie pakowane po 1kg. Smaki galaretki : malinowa, pomarańczowa, ananasowa i cytrynowa. Sprzedaż tylko na całe opakowania. Termin ważności minimum 3 miesiące od zakupu. Przy większych zakupach lub z kilku aukcji za wysyłkę płacisz tylko raz." },
                new Item() { Id = 21, Name = "Cukierki Pastylka miętowa w czekoladzie Wawel – 1kg", Price = 37.9M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Pyszna Pastylka miętowa firmy Wawel. Czekoladki miętowe Wawel mają kształt pastylek oblanych pyszną czekoladą. Każda z nich jest opakowana osobno, dlatego po rozwinięciu mają idealnie świeży i bardzo intensywny smak. To niesamowite połączenie mięty i słodkości, które nada się do przekąszenia lub jako prezent. Pakowane po 1kg. Sprzedaż tylko na całe opakowania a w jednym znajduje się około 70 sztuk. Termin ważności minimum 3 miesiące od zakupu." },
                new Item() { Id = 22, Name = "Cukierki Toffino Choco – 80g", Price = 3.890M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Pyszne cukierki polskiej firmy Goplana: Toffi mleczne nadziewane kremem czekoladowym (18%) pakowane po 80g. Sprzedaż tylko na całe opakowania. Termin ważności minimum 4 miesiące od zakupu. Przy większych zakupach lub z kilku aukcji za wysyłkę płacisz tylko raz. Proszę pilnować wagi produktów oraz koszt wysyłki." },
                new Item() { Id = 23, Name = "Nimm2 Śmiejżelki – 100g", Price = 4.5M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Nimm2 Śmiej Żelki to żelki owocowe wzbogacana witaminami : E, B6, B12, biotyną. Produkcja Śmiejżelków nimm2 jest stale nadzorowana. Producent Storck gwarantuje najwyższą jakość dzięki zastosowaniu składników najwyższego gatunku oraz stałej kontroli jakości. W każdym opakowaniu znajduje 100g żelków. Waga 1 opakowania do wysyłki to 0,2kg. Sprzedaż na opakowania. Termin ważności minimum 4 miesiące od zakupu." },
                new Item() { Id = 24, Name = "Nimm2 Śmiejżelki jogurtowe - 100g", Price = 4.5M, Amount = 100, Category = "Cukierki", AddedToShop = DateTime.Now, Description = "Zestaw 5 paczek żelków jak na zdjęciu powyżej. W skład zestawu wchodzą : paczka żelków kwaśnych, jogurtowych, mlekoduszków, happies oraz tradycyjnych owocowych śmiej żelkówNimm2 Śmiej Żelki to żelki owocowe wzbogacana witaminami : E, B6, B12, biotyną. Produkcja Śmiej żelków nimm2 jest stale nadzorowana. Producent Storck gwarantuje najwyższą jakość dzięki zastosowaniu składników najwyższego gatunku oraz stałej kontroli jakości. W każdym opakowaniu znajduje 100g żelków a żelki happies to 130g. Waga 1 zestawu do wysyłki to 0,8kg. Sprzedaż na opakowania. Termin ważności minimum 4 miesiące od zakupu." }
           );

        builder.Entity<Address>()
            .HasData(
                new Address() { Id = 1, City = "Wrocław", Street = "Legnicka", Number = "156", SubNumber = null, PostalCode = "50-123", },
                new Address() { Id = 2, City = "Wrocław", Street = "Górnickiego", Number = "22", SubNumber = "37", PostalCode = "52-456", },
                new Address() { Id = 3, City = "Sokołów Młp.", Street = "Rzeszowska", Number = "44", SubNumber = null, PostalCode = "36-050", },
                new Address() { Id = 4, City = "Rzeszów", Street = "Architektów", Number = "123", SubNumber = null, PostalCode = "37-167", }
            );

        builder.Entity<Customer>()
            .HasData(
                new Customer() { Id = 1, Name = "Michau", Surname = "Stanislau" },
                new Customer() { Id = 2, Name = "Władysław", Surname = "Włodecki" },
                new Customer() { Id = 3, Name = "Tomek", Surname = "Polok" },
                new Customer() { Id = 4, Name = "Aleksandra", Surname = "Schabowicka" }
            );

        customerAddress.HasData(
            new { AddressId = 1, CustomerId = 1 },
            new { AddressId = 1, CustomerId = 2 },
            new { AddressId = 2, CustomerId = 3 },
            new { AddressId = 3, CustomerId = 4 },
            new { AddressId = 4, CustomerId = 4 }
        );

        users.HasData(
                new User()
                {
                    Id = 1,
                    Email = "user@example.com",
                    PasswordHash = Convert.FromHexString("06ABE76258A3A95573FEEFAB8DBEDCFE0C8C8C446A998188543B3A64BDA5E85011F29E8DB00879DE6DCB6077D9F4002A01549414849A913DAABCF7E9D3529F44"),
                    PasswordSalt = Convert.FromHexString("EFDB8832074402985B10F01E1518636E411B475576F4C07257C7659D523034DA3286EBB8779CFB6B4B2E572D221FFD5BC863E34B6C6AB0C8340F5A4328CC789A61158BB8AF6FCC472DCAA02931F78E2E65CA73C379B157777966F359690FCDC4B834FFED1988EC78E98B39FF92B2AC9BCC84B53DECA107E4159237F7AC8C4F09"),
                    CustomerId = 1
                }
            );

        carts.HasData(
                new Cart() { Id = 1, CustomerId = 3, ItemId = 2, Amount = 5 },
                new Cart() { Id = 2, CustomerId = 3, ItemId = 3, Amount = 20 },
                new Cart() { Id = 3, CustomerId = 1, ItemId = 1, Amount = 20 },
                new Cart() { Id = 4, CustomerId = 1, ItemId = 2, Amount = 1 },
                new Cart() { Id = 5, CustomerId = 1, ItemId = 3, Amount = 3 },
                new Cart() { Id = 6, CustomerId = 1, ItemId = 4, Amount = 4 }
            );

        orders.HasData(
                new Order()
                {
                    Id = 1,
                    CreationDate = DateTime.Parse("2022-10-22 23:32:00"),
                    CustomerId = 1,
                    InvoiceAddressId = 1,
                    ShippingAddressId = 2,
                    ShipmentType = "Kurier",
                    Status = "Zatwierdzone"
                },
                new Order()
                {
                    Id = 2,
                    CreationDate = DateTime.Parse("2022-10-23 10:00:00"),
                    CustomerId = 2,
                    InvoiceAddressId = 1,
                    ShippingAddressId = 1,
                    ShipmentType = "InPost",
                    Status = "Wysłane"
                }
            );

        orderDetails.HasData(
                new OrderDetail() { Id = 1, OrderId = 1, ItemId = 1, Amount = 10 },
                new OrderDetail() { Id = 2, OrderId = 1, ItemId = 2, Amount = 1 },
                new OrderDetail() { Id = 3, OrderId = 1, ItemId = 3, Amount = 3 },
                new OrderDetail() { Id = 4, OrderId = 1, ItemId = 4, Amount = 1 },
                new OrderDetail() { Id = 5, OrderId = 2, ItemId = 1, Amount = 40 },
                new OrderDetail() { Id = 6, OrderId = 2, ItemId = 3, Amount = 20 },
                new OrderDetail() { Id = 7, OrderId = 2, ItemId = 4, Amount = 1 }
            );
    }
}
