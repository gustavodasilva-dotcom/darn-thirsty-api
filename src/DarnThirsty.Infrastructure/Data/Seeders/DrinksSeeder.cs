using DarnThirsty.Core.Data;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Enums;
using MongoDB.Driver;

namespace DarnThirsty.Infrastructure.Data.Seeders;

public static class DrinksSeeder
{
    public static void Run(IMongoContext mongoContext)
    {
        try
        {
            void Seed(Drink drink)
            {
                if (mongoContext.Drinks.FindSync(d => d.name.Equals(drink.name)).FirstOrDefault() == null)
                    mongoContext.Drinks.InsertOne(drink);
            }

            var cocktail = mongoContext.DrinkTypes.FindSync(t => t.code == (int)DrinkTypesEnum.Cocktail).FirstOrDefault();

            Seed(new Drink
            {
                name = "Gin & Tonic",
                image = Path.Combine("Assets", "_default", "gin_and_tonic.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "Gin & Tonic. If you can say it, you can make it. Right? Right. But also, not exactly. The two-ingredient cocktail requires your undivided attention. From glassware to garnish to style of gin and spirit proof, everything should be carefully considered when mixing a G&T.",
                    "A Gin & Tonic made with a potent base—45% ABV and above, if you mean business—and configured with two parts tonic to one part gin is a highball of balance and beauty. Too much gin, and the botanical spirit will overshadow the unique qualities of the tonic. Too much tonic, and it will drown the gin.",
                    "There is endless room for experimentation within those two ingredients. With hundreds of gins on the market and dozens of tonics, a good G&T is a mix-and-match exercise to find the combination that best suits your tastes. London dry gins are characterized by their juniper-forward flavor profile; modern-style gins often dial down the juniper and ramp up the citrus and florals. Some tonics are dry and straightforward, with prominent notes of bitter quinine. Others are sweet and syrupy. And in between, you’ll find tonics featuring everything from citrus and aromatics to herbs and spice. Then, of course, there’s the garnish. Many people swear by a lime. Others choose a lemon, and still others prefer a grapefruit slice or rosemary sprig, or a seasonal garnish such as blood orange and thyme.",
                    "All those permutations results in a bevy of Gin & Tonics, so naturally, the drink lends itself to creativity. Muddled cucumbers or fruit provide an extra dose of refreshment, and a measure of dry vermouth softens the cocktail. Liqueurs, fresh herbs and even barrel-aged gin are all fair game when you’re making G&Ts. It’s an impressive résumé for a drink that traces its roots to quinine powder, which was used in the 1840s as an antimalarial for British soldiers and citizens in India.",
                    "Originally, the bitter quinine powder was mixed with soda and sugar to make it more palatable. It wasn’t long before enterprising sorts bottled the elixir for commercial use. And soon after that, tonic made its way into gin.",
                    "Today, tonic features less quinine than past products, and it has a sweeter taste. But its ability to complement gin is unparalleled among mixers. Put the two together in a glass, and you can taste one of the cocktail canon’s best pairings and raise your glass to the knowledge that Gin & Tonics are, essentially, medicine."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces gin",
                        "4 ounces tonic water",
                        "Garnish: 2 lime wheels or other seasonal garnishes you may prefer"
                    },
                    steps = new string[]
                    {
                        "Fill a highball glass with ice, then add the gin.",
                        "Top with the tonic water and gently stir.",
                        "Garnish with lime wheels or seasonal garnishes"
                    }
                }
            });

            Seed(new Drink
            {
                name = "White Russian",
                image = Path.Combine("Assets", "_default", "white_russian.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The White Russian is a decadent and surprisingly easy-to-make cocktail. Combining vodka, Kahlúa and cream and serving it on the rocks creates a delicious alternative to adult milkshakes.",
                    "The White Russian came about in the ’60s when someone added a bit of cream to the Black Russian, rendering it white. Neither drink is Russian in origin, but the name refers to the vodka, a spirit often associated with Russia.",
                    "It would be a great story to say that the White Russian’s star rose from that point on, but that would not be true. The truth is the White Russian suffered a bit from a stodgy, antiquated reputation until the 1998 movie “The Big Lebowski” came along and breathed new life into the cocktail with Jeff Bridges’ character, the Dude, sipping it exclusively—and constantly. It’s one of popular culture’s best drinks-related successes, right up there with Carrie Bradshaw’s impact on the Cosmo. Of course, if you want to order it like the Dude, throw in the occasional call for a “Caucasian.” The barkeep will know what you mean.",
                    "When making a White Russian at home, choose a decent vodka (a Russian one, if you want to stay on theme) and a good heavy cream. Half-and-half can work in a pinch, but milk will produce a thin drink. Remember: You’re aiming for decadence."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces vodka",
                        "1 ounce Kahlúa",
                        "1 splash heavy cream"
                    },
                    steps = new string[]
                    {
                        "Add the vodka and Kahlúa to a rocks glass filled with ice.",
                        "Top with the heavy cream and stir."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Aviation",
                image = Path.Combine("Assets", "_default", "aviation.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The Aviation is a classic gin cocktail dating back to the turn of the 20th century, and it first appeared in Huge Enslinn’s book “Recipes for Mixed Drinks” in 1916 while he was tending bar at New York City’s Hotel Wallick. In the ensuing decades, it was all but forgotten. That’s because one of the drink’s primary ingredients, crème de violette liqueur, disappeared from the market during the 1960s.",
                    "In 2007, Minneapolis importer Haus Alpenz began importing Rothman & Winter crème de violette from Austria right at the height of the craft cocktail renaissance. The liqueur’s newfound availability led to the Aviation reappearing on bar menus across the United States market, as bartenders rediscovered this classic recipe.",
                    "The Aviation combines gin, maraschino liqueur and fresh lemon juice alongside that crème de violette, creating a unique, floral cocktail. Gin provides a sturdy base, while maraschino liqueur lends its trademark bittersweet cherry notes and lemon adds necessary acidity. Crème de violette is exceedingly flower-like, so it’s important to use it sparingly and measure your ingredients. Too much, and your Aviation will taste like a bowl of potpourri.",
                    "Beyond Rothman & Winter’s bottle, you can also try Creme Yvette, a historic liqueur that was revived in 2009, 40 years after production stopped. It’s made from parma violet petals and also features blackberries, raspberries, strawberries, orange peel, honey and vanilla. Brands including The Bitter Truth and Giffard also now offer violet liqueurs that work well in the Aviation.",
                    "Some will argue that you can’t make a proper Aviation without the violet-hued liqueur. However, during its absence, the Aviation continued to find favor among enterprising drinkers who simply made the drink without it. This was likely fueled in part by “The Savoy Cocktail Book,” in which author Harry Craddock included a violette-less Aviation in his 1930 tome. That makes an interesting drink to be sure, but if you want to taste the original recipe, you need the purple stuff.",
                    "Regardless of which brand you choose, let’s hope that at least one of these examples sticks around. That way, consumers will never again have to live in a world without crème de violette."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces gin",
                        "1/2 ounce maraschino liqueur",
                        "1/4 ounce creme de violette",
                        "3/4 ounce lemon juice, freshly squeezed",
                        "Garnish: brandied cherry"
                    },
                    steps = new string[]
                    {
                        "Add the gin, maraschino liqueur, creme de violette and lemon juice to a shaker with ice and shake until well-chilled.",
                        "Strain into a cocktail glass.",
                        "Garnish with a brandied cherry."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Vieux Carré",
                image = Path.Combine("Assets", "_default", "vieux_carre.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "New Orleans has played a significant role in cocktail culture over the past century-plus. The City That Care Forgot has been responsible for classics like the Sazerac and Ramos Gin Fizz. Its contributions also include the Vieux Carré, which was first stirred to life during the 1930s by Walter Bergeron, a bartender at New Orleans’ legendary Carousel Bar (then known as the Swan Room) inside the Hotel Monteleone. Vieux Carré means “old square” in French and refers to the city’s French Quarter neighborhood.",
                    "Like so many classic cocktails from that city, the recipe represents the crosscurrents of America at the time: brandy and liqueur from France, vermouth from Italy, and rye whiskey from just up the Mississippi. The Vieux Carré is at once boozy, sweet, bitter and smooth—in other words, it’s New Orleans in a glass.",
                    "The drink features several strong ingredients. In most cases, rye or cognac could carry a cocktail on their own, but the Vieux Carré calls for both in a split-base technique that allows each component to shine. The rye provides muscular spice, while the cognac lends softer notes of fruit and florals. Sweet vermouth adds rich botanicals, while Bénédictine brings its distinct flavors of herbs, spices and honey. Finally, the bitters add structure and seasoning. Each element has a role to play; when combined, the ingredients meld seamlessly.",
                    "This recipe comes from legendary bartender Dale DeGroff, aka King Cocktail. He subs the classic combination of Angostura and Peychaud’s bitters for his own pimento aromatic bitters, which bring similar accents of baking spices and anise to the drink. He also chooses George Dickel rye from Tennessee. But any good rye whiskey will do the job, so feel free to experiment with your favorite bottle.",
                    "Today the Vieux Carré can be found on cocktail menus across the country, alongside other New Orleans classics like the Sazerac. If you find yourself in the French Quarter, don’t pass up a chance to drink one straight from the source. The cocktail is potent, but note that the Carousel Bar is famous for its revolving bar. So, if the room feels like it’s spinning, don’t worry: It is."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "3/4 ounce George Dickel rye whiskey",
                        "3/4 ounce cognac",
                        "3/4 ounce sweet vermouth",
                        "2 teaspoons Benedictine liqueur",
                        "4 dashes Dale DeGroff’s pimento aromatic bitters",
                        "Garnish: maraschino cherry or lemon twist"
                    },
                    steps = new string[]
                    {
                        "Add the rye whiskey, cognac, sweet vermouth, Benedictine and bitters into a mixing glass with ice and stir until well-chilled.",
                        "Strain into a rocks glass over fresh ice or a cocktail glass.",
                        "Garnish with a cherry, a lemon twist or both."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Aperol Spritz",
                image = Path.Combine("Assets", "_default", "aperol_spritz.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "Walk through an Italian town during the late-afternoon—particularly in Northern cities like Milan and Venice—and you’ll find groups of people enjoying Aperol Spritzes. The after-work spritz is a long-established Italian tradition, and fortunately, it’s one that’s easily replicated anywhere.",
                    "Aperol traces its roots back to Padua, Italy. The aperitivo—an appetite-whetting beverage designed to be consumed before dinner—was created in 1919. Its bittersweet flavor, aromatic botanicals and easygoing alcohol content (it’s only 11% ABV) made it the perfect choice for pre-dinner sipping.",
                    "Pair Aperol with bubbly wine and sparkling water, and you’ll be hard-pressed to find a more refreshing and thirst-quenching cocktail. And because it’s low in alcohol, you can start drinking early and still make it to dinner.",
                    "While the Aperol Spritz has been enjoyed in Italy for more than a century, it didn’t reach mass appeal in the United States until the 2010s, as drinkers became more familiar with aperitivos and lower-alcohol drinks. Today, it’s a staple at cocktail bars, Italian and non-Italian restaurants, and it can be found almost anywhere that serves brunch on sunny patios.",
                    "The Aperol Spritz is also a great candidate for at-home cocktail hour since it’s as easy to make as it is to drink. The three ingredients are simply combined in the glass with ice, no shaking, stirring or elaborate flourishes required. Once complete, the drink’s deliciously complex flavor and gorgeous coral hue belie you having created a classic cocktail in two minutes.",
                    "While any sparkling wine can be combined with Aperol and soda, note that a true Aperol Spritz calls specifically for Italian bubbly. Proseccos range from sweet to dry, so choose one that hits the sweetness level you prefer. Then make yourself a drink and relax. You might not be in Italy, but with a good cocktail in hand, you can at least channel the country’s long-standing tradition of aperitivo hour."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "3 ounces prosecco",
                        "2 ounces Aperol",
                        "1 ounce club soda",
                        "Garnish: orange slice"
                    },
                    steps = new string[]
                    {
                        "Add the prosecco, Aperol and club soda to a wine glass filled with ice and stir.",
                        "Garnish with an orange slice."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Moscow Mule",
                image = Path.Combine("Assets", "_default", "moscow_mule.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The Moscow Mule is a classic vodka-based cocktail that is popular for good reason: It’s delicious, refreshing and a snap to make. Just speaking the drink’s name conjures images of the ice-cold copper mug that is the de rigueur vessel for the Moscow Mule.",
                    "The simple cocktail combines vodka with ginger beer and lime. It’s a no-tools-required drink that is built right in the mug. Of course, while said mug is always preferred for serving, it’s not essential and shouldn’t deter you from making a Moscow Mule. The drink tastes great no matter the receptacle. So if a highball glass or rocks glass is all you have on hand, don’t fret.",
                    "Any high-quality vodka will work nicely in the mule, but now is not the time to experiment with subpar ginger beer. You want a top-notch option that comes from a bottle, not a soda gun, and offers enough spicy bite to complement the liquor and lime. Put the components together, and it’s hard to think of a more restorative choice on a hot summer day.",
                    "The Moscow Mule is a mid-century classic that was born in 1941 and helped contribute to vodka’s rise in America. As the legend goes, it was concocted by two men. John Martin needed to sell Smirnoff vodka, a new and generally unknown spirit at the time that his distribution company had recently purchased. Another man, bar owner Jack Morgan, needed to deplete the stash of ginger beer taking up space at his Cock ‘n’ Bull pub. They decided to combine the two ingredients with a little lime, and the rest is history. Well, minus the mug. No one’s quite sure where that came from, but there are reports of a third party at that meeting with a fortuitous supply of copper mugs. Regardless of how the drink was invented, the easygoing combination of vodka, spicy ginger and tart lime—all packaged neatly in an eye-catching mug—was a hit. More than a quarter century later, the Moscow Mule remains a hit.",
                    "This recipe brings the legendary drink up to date while remaining true to its refreshing roots. At its core, the Moscow Mule is deceptively simple and incredibly easy to mix, perfect for any season."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces vodka",
                        "1/2 ounce lime juice, freshly squeezed",
                        "3 ounces ginger beer, chilled",
                        "Garnish: lime wheel"
                    },
                    steps = new string[]
                    {
                        "Fill a Moscow Mule mug (or highball glass) with ice, then add the vodka and lime juice.",
                        "Top with the ginger beer.",
                        "Garnish with a lime wheel."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Grasshopper",
                image = Path.Combine("Assets", "_default", "grasshopper.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The Grasshopper is a green blast from the past featuring green creme de menthe, white creme de cacao and heavy cream. Creme de menthe is a liqueur made by adding mint leaves or extract to neutral alcohol, after which it’s filtered, sweetened, lightly aged and bottled. And white creme de cacao is a sweet, chocolate-flavored liqueur with a buttery mouthfeel.",
                    "The drink was allegedly created in 1919 in New Orleans, but it didn’t become a household name until the 1950s, as Prohibition squandered the growth and familiarity of many cocktails born just before the restricted-drinking era began. The original recipe calls for the three ingredients to be combined in equal parts, resulting in a cocktail that looks like melted mint-chocolate-chip ice cream and kind of tastes like it, too.",
                    "The rich, green-hued dessert cocktail became a mainstay at bars during the disco era, while in contemporary times, bartenders have upended the core blueprint, creating clarified grasshoppers, grasshopper milkshakes and other playful riffs on the flavorful classic.",
                    "This version comes from New York bartending legend Dale DeGroff, who breaks the equal-parts formula and cranks up the heavy cream to round out the drink. Shake your ingredients with ice and, if you’re feeling fancy, dust some nutmeg on top. The Grasshopper can be consumed any time of day, of course, but given its sweet and creamy nature, it’s particularly effective after dinner. Order one after a good meal or make one at home in lieu of dessert."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "1 ounce green creme de menthe",
                        "1 ounce white creme de cacao",
                        "2 ounces heavy cream",
                        "Garnish: nutmeg, freshly grated (optional)"
                    },
                    steps = new string[]
                    {
                        "Add the green creme de menthe, white creme de cacao and heavy cream into a shaker with ice and shake vigorously until well-chilled.",
                        "Strain into a chilled cocktail glass.",
                        "Grate nutmeg over the top of the drink, if desired."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Gimlet",
                image = Path.Combine("Assets", "_default", "gimlet.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The classic Gimlet cocktail is a three-ingredient masterclass in simplicity and balance. Composed only of gin, lime juice, and sugar, it helped pave the way for countless cocktails to follow, from the Margarita to the Daiquiri and the Sidecar.",
			        "Over a century later, the Gimlet remains an icon of what's now referred to as the sour category of drinks. It's given rise to variations like the Vodka Gimlet, and its basic template has become so intertwined in cocktail culture that certain drinks, like the Daiquiri, could just as easily be described as a \"Rum Gimlet.\"",
			        "As for who first combined Rose's cordial with navy rations of gin, the story gets murkier. Many like to credit Rear-Admiral Sir Thomas Desmond Gimlette, a British naval doctor, for popularizing the cocktail. Others say it was named after a tool used to bore holes on ships. Like most pre-20th-century cocktails, particularly one that come from such a simple a template—spirit, sugar, and citrus—it's hard to pin down a single point of origin.",
			        "What we do know is that by the 1940–50s, the classic Gimlet was codified in both popular culture and many cocktail books as a simple 50/50 mix of Rose's Lime Juice Cordial and gin. However, much as the Whiskey Sour rebounded from the \"sour mix era\" to once again use fresh ingredients, the Gimlet also began to revert back to what the Rose's version only tried to approximate: a combination of gin, fresh lime juice, and sugar.",
			        "The Gimlet follows the basic sour template of spirit, citrus, and sugar. This combination features prominently in so many drinks throughout history because of how flexible it is, and how well it works.",
			        "Sugar and citric acid act on opposite ends of the sweet-to-sour spectrum, and effectively balance each other out. This creates a drink that, when mixed appropriately, is neither sweet nor sour (despite what we call the category), but simply tart and refreshing. Once both side of these two flavor profiles are in sync, the base spirit is able to reflect the best of both worlds, while shining through on its own without being overpowered.",
			        "Many cite the \"golden ratio\" of sour drinks as 2:1:1—this means two parts of base liquor, one part sweet, and one part sour. This is often used as shorthand, particularly for drink novices, as it will almost guarantee a decent drink across a wide range of ingredients. But part of the reason the style persists is that it's easy, and often preferable, to tweak the balance to individual tastes.",
			        "Modern tastes tend to favor more spirit-forward combinations, particularly as the quality of distillates around the world has risen dramatically since many of these classic cocktails were first created. With the Gimlet, we've opted for an even balance of simple syrup to lime juice in an effort to capture the original intent of the drink, but slightly reduced the amount of each while increasing the volume of gin, to reflect an era of fresh ingredients and lower-proof gin than those found on British naval vessels."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 1/2 ounces gin",
				        "1/2 ounce lime juice, freshly squeezed",
				        "1/2 ounce simple syrup",
				        "Garnish: lime wheel"
                    },
                    steps = new string[]
                    {
                        "Add the gin, lime juice and simple syrup to a shaker with ice and shake until well-chilled.",
				        "Strain into a chilled cocktail glass or an rocks glass filled with fresh ice.",
				        "Garnish with a lime wheel."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Negroni",
                image = Path.Combine("Assets", "_default", "negroni.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "Easy to make and refreshingly bitter, the Negroni is said to have been invented in Florence by the dauntless Italian Count Camillo Negroni in the early 20th century. While at Bar Casoni in Florence, he demanded that the bartender strengthen his favorite cocktail, the Americano, by replacing the usual soda water with gin. To further differentiate the drink, the bartender also employed an orange peel rather than the typical lemon peel.",
			        "It’s a widely accepted tale, and one that is documented in “Sulle Tracce del Conte: La Vera Storia del Cocktail Negroni,” which was written by Lucca Picchi, the head bartender at Caffe Rivoire in Florence, Italy, and translates to “In the Footsteps of the Count: The True Story of the Negroni Cocktail.” The count’s fateful substitution resulted in one of the most popular stirred drinks in history, as the Negroni sits next to the Martini and Manhattan in the pantheon of classics. It also launched a thousand riffs, and today the Negroni can be found in myriad iterations at restaurants and cocktail bars around the world.",
			        "Few cocktails have encouraged more frenzied experimentation than the beloved Negroni during the course of its 100-year history. Its one-to-one-to-one recipe of gin, Campari and sweet vermouth has become the platform on which generations of drink mixers have left their thumbprint. Sub bourbon for gin, and you’ve got the Boulevardier, a great cocktail in its own right. Try rum or mezcal in the same equal parts configuration with Campari and sweet vermouth, and you get far different yet equally balanced and impressive drinks.",
			        "There are more ways to tweak the Negroni than by simply swapping its base spirit. The type of vermouth used can have an impact on the outcome too. Pick one that is more bitter, herbal, floral or dry, and you’ll notice the difference. But Campari? That almost always stays put. You can try experimenting with a different bitter liqueur, and some bartenders do. But Campari is the one ingredient that nearly all Negronis have in common.",
			        "So, how do you mix the perfect classic version? Start by selecting the right base materials. The key to a great Negroni is finding a gin-vermouth pairing that complements, rather than overpowers, the bitter, bold flavors of Campari. Once you zero in on a winning trio, write it down, memorize it, and request it at your favorite bar. You’ll gain the barkeep’s respect, make the count proud and, most important, enjoy a good drink."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "1 ounce gin",
				        "1 ounce Campari",
				        "1 ounce sweet vermouth",
				        "Garnish: orange peel"
                    },
                    steps = new string[]
                    {
                        "Add the gin, Campari and sweet vermouth to a mixing glass filled with ice, and stir until well-chilled.",
				        "Strain into a rocks glass over a large ice cube.",
				        "Garnish with an orange peel."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Gold Rush",
                image = Path.Combine("Assets", "_default", "gold_rush.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "On paper, the Gold Rush is a very simple drink. Composed of bourbon, honey syrup and fresh lemon juice, it’s essentially a Whiskey Sour with honey in place of sugar. This also essentially makes it a variation on the classic Bee’s Knees cocktail, but one that uses bourbon rather than gin. The interplay of whiskey and honey transforms the cocktail’s flavor and mouthfeel, making the Gold Rush a drink that transcends the sum of its parts.",
			        "The Gold Rush was first created at famed New York City bar Milk & Honey in the early 2000s, and became a staple of bars worldwide at such a pace that the cocktail is often commonly assumed to have been a pre-Prohibition classic, rather than a modern drink. But its appearance came at a time when new drinks were appearing all over the U.S. fueled by a new generation of craft bartenders experimenting with tweaks to classic cocktails. Newly available liqueurs were poured liberally, alternate base spirits were swapped into tried-and-true recipes, and rules were broken with regularity.",
			        "This era resulted in many great success stories like the Gold Rush, as well as the Penicillin, another Milk & Honey creation which follows the same template but substitutes Scotch whiskey for bourbon, and incorporates a touch of ginger."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces bourbon",
				        "3/4 ounce lemon juice, freshly squeezed",
				        "3/4 ounce honey syrup",
				        "Garnish: lemon twist"
                    },
                    steps = new string[]
                    {
                        "Add the bourbon, honey syrup, and lemon juice into a shaker with ice and shake until well-chilled.",
				        "Strain into a chilled rocks glass over one large ice cube.",
				        "Garnish with a lemon twist."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Penicillin",
                image = Path.Combine("Assets", "_default", "penicillin.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "The Penicillin cocktail was created by Sam Ross in the mid-2000s, when he was working at New York City’s famous Milk & Honey bar. The drink quickly gained a foothold as a modern-classic cocktail. It’s now served around the world, proving its status as one of the 21st century’s biggest cocktail success stories.",
			        "In creating the drink, Ross decided to riff on the Gold Rush, another Milk & Honey original, that features bourbon, lemon juice and honey. He skipped the bourbon and instead opted to mix blended scotch with fresh lemon and a homemade honey-ginger syrup, which added sweetness and the classic bite of ginger. Ross then added a float of peaty scotch from Islay, an island known for producing smoky whiskies.",
			        "The blended scotch, lemon and sweetened syrup create balance in the drink, similar to that which you’ll find in a Whiskey Sour. The Penicillin is sweet, tart, spicy and delicious, garnished with a welcome snack of candied ginger. But that topper of Islay scotch is the genius behind the cocktail, keeping the spirit’s smoky aromatics front and center with each sip. As such, Ross prefers to serve the drink without a straw—so you don’t miss a single note."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "2 ounces blended scotch",
				        "3/4 ounce lemon juice, freshly squeezed",
				        "3/4 ounce honey-ginger syrup*",
				        "1/4 ounce Islay single malt scotch",
				        "Garnish: candied ginger"
                    },
                    steps = new string[]
                    {
                        "Add the blended scotch, lemon juice and syrup into a shaker with ice, and shake until well-chilled.",
				        "Strain into a rocks glass over fresh ice.",
				        "Top with the Islay single malt scotch.",
				        "Garnish with a piece of candied ginger."
                    }
                }
            });

            Seed(new Drink
            {
                name = "Paper Plane",
                image = Path.Combine("Assets", "_default", "paper_plane.jpg"),
                type = cocktail,
                about = new string[]
                {
                    "One might imagine that the Paper Plane, considering the drink’s ubiquity among bartenders and at cocktail bars, were a storied classic. However, it was only invented in 2008. The inventor: Sam Ross, an award-winning bartender and the co-owner of Attaboy and Diamond Reef in New York City.",
			        "The Paper Plane is a modern variation on the Last Word, a classic, equal-parts drink composed of gin, lime, maraschino liqueur and green Chartreuse. At first glance, the bourbon-spiked Paper Plane might not seem too similar. But it follows the same template and consists of equal parts bourbon, Amaro Nonino, Aperol and lemon juice. Both drinks strike a beautiful balance between bitter, sour and herbal notes.",
			        "Although Ross typically holds court in NYC, he created the cocktail for the menu of The Violet Hour in Chicago. He was inspired by M.I.A.’s smash hit “Paper Plane,” which was popular at the time, and he even garnished the drink with a little paper plane. Guests enjoyed the cocktail, so Ross brought it with him when he went back to New York. He served it at Milk & Honey, and the cocktail’s following proliferated from there.",
			        "When making the Paper Plane, Ross likes to use a slightly higher-proof bourbon—one in the 43% to 46% ABV range—as heft adds body. He also warns not to overshake the drink: You want it cold, but not watery. With that in mind, you can try making one for yourself. Made with equal parts of each ingredient, it’s an easy exercise.",
			        "Bourbon and lemon juice are mainstays in most home bars. Aperol, as the backbone of the popular Aperol Spritz, is easy to come by. Amaro Nonino is a friendly, bittersweet ingredient that adds a unique element to the cocktail. This liqueur is made from a base of grappa and includes notes of botanicals, alpine herbs and orange peel.",
			        "Mix the components together for a lesson in flavor and balance. The bourbon is present, but not overwhelming, making the Paper Plane a great gateway cocktail for drinkers who are new to whiskey. And while it’s still a relatively new drink, its impact has been significant. Don’t be surprised if it sticks around for decades to come."
                },
                recipe = new Recipe
                {
                    ingredients = new string[]
                    {
                        "3/4 ounce bourbon",
				        "3/4 ounce Aperol",
				        "3/4 ounce Amaro Nonino Quintessentia",
				        "3/4 ounce lemon juice, freshly squeezed"
                    },
                    steps = new string[]
                    {
                        "Add the bourbon, Aperol, Amaro Nonino and lemon juice into a shaker with ice and shake until well-chilled.",
				        "Strain into a coupe glass."
                    }
                }
            });
        }
        catch (Exception e)
        {
            throw new Exception(string.Format("{0} - : {1}", nameof(DrinksSeeder), e.Message));
        }
    }
}