using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed.Catalogs;

public static class CountriesSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var countries = new List<Pais>()
        {
            new()
            {
                Id = "ABW",
                Nombre = "Aruba",
                Nacionalidad = "Holandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AFG",
                Nombre = "Afghanistan",
                Nacionalidad = "Afgana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AGO",
                Nombre = "Angola",
                Nacionalidad = "Angola",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AIA",
                Nombre = "Anguilla",
                Nacionalidad = "Anguilla",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ALB",
                Nombre = "Albania",
                Nacionalidad = "Albanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AND",
                Nombre = "Andorra",
                Nacionalidad = "Andorrana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ANT",
                Nombre = "Antillas Holandesas",
                Nacionalidad = "Holandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ARE",
                Nombre = "Emiratos Arabes Unidos",
                Nacionalidad = "Emiratense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ARG",
                Nombre = "Argentina",
                Nacionalidad = "Argentina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ARM",
                Nombre = "Armenia",
                Nacionalidad = "Armenia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ASM",
                Nombre = "Samoa Americana",
                Nacionalidad = "Norte Americana (Samoa)",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ATA",
                Nombre = "Antartica",
                Nacionalidad = "Antartica",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ATF",
                Nombre = "Territorio del Sur de Francia",
                Nacionalidad = "Francesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ATG",
                Nombre = "Antigua y Barbuda",
                Nacionalidad = "Antigua y Barbuda",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AUS",
                Nombre = "Australia",
                Nacionalidad = "Australiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AUT",
                Nombre = "Austria",
                Nacionalidad = "Austriaca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "AZE",
                Nombre = "Azerbaijan",
                Nacionalidad = "Azerbaijan",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BDI",
                Nombre = "Burundi",
                Nacionalidad = "Burundi",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BEL",
                Nombre = "Belgica",
                Nacionalidad = "Belga",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BEN",
                Nombre = "Benin",
                Nacionalidad = "Benin",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BFA",
                Nombre = "Burkina Faso",
                Nacionalidad = "Burkina Faso",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BGD",
                Nombre = "Bangladesh",
                Nacionalidad = "Bangladesh",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BGR",
                Nombre = "Bulgaria",
                Nacionalidad = "Bulgara",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BHR",
                Nombre = "Bahrain",
                Nacionalidad = "Bahrain",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BHS",
                Nombre = "Bahamas",
                Nacionalidad = "Bahamesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BIH",
                Nombre = "Bosnia and Herzegovina",
                Nacionalidad = "Bosnia and Herzegovina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BLR",
                Nombre = "Belarus",
                Nacionalidad = "Bielorrusa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BLZ",
                Nombre = "Belice",
                Nacionalidad = "Beliceña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BMU",
                Nombre = "Bermuda",
                Nacionalidad = "Bermudesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BOL",
                Nombre = "Bolivia",
                Nacionalidad = "Boliviana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BRA",
                Nombre = "Brasil",
                Nacionalidad = "Brasileña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BRB",
                Nombre = "Barbados",
                Nacionalidad = "Barbadense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BRN",
                Nombre = "Brunei",
                Nacionalidad = "Brunei",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BTN",
                Nombre = "Butan",
                Nacionalidad = "Butana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BVT",
                Nombre = "Bouvet Island",
                Nacionalidad = "Bouvet Island",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "BWA",
                Nombre = "Botswana",
                Nacionalidad = "Botswana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CAF",
                Nombre = "Republica Central de Africa",
                Nacionalidad = "Africana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CAN",
                Nombre = "Canada",
                Nacionalidad = "Canadiense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CCK",
                Nombre = "Islas Cocos (Keeling)",
                Nacionalidad = "Australiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CHE",
                Nombre = "Suiza",
                Nacionalidad = "Suiza",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CHL",
                Nombre = "Chile",
                Nacionalidad = "Chilena",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CHN",
                Nombre = "China",
                Nacionalidad = "China",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CIV",
                Nombre = "COSTA DE MARFIL",
                Nacionalidad = "Marfileña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CMR",
                Nombre = "Camerun",
                Nacionalidad = "Camerunes",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "COG",
                Nombre = "Congo",
                Nacionalidad = "Congolesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "COK",
                Nombre = "Islas Cook",
                Nacionalidad = "Islas Cook",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "COL",
                Nombre = "Colombia",
                Nacionalidad = "Colombiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "COM",
                Nombre = "Comoros",
                Nacionalidad = "Francesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CPV",
                Nombre = "Cabo Verde",
                Nacionalidad = "Caboverdiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CRI",
                Nombre = "Costa Rica",
                Nacionalidad = "Costarricense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CUB",
                Nombre = "Cuba",
                Nacionalidad = "Cubana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CXR",
                Nombre = "Isla Navidad",
                Nacionalidad = "Isla Navidad",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CYM",
                Nombre = "Islas Caiman",
                Nacionalidad = "Caimanes",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CYP",
                Nombre = "Chipre",
                Nacionalidad = "Chipriota",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "CZE",
                Nombre = "Republica Checa",
                Nacionalidad = "Checa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DEU",
                Nombre = "Alemania",
                Nacionalidad = "Alemana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DJI",
                Nombre = "Yibuti",
                Nacionalidad = "Yibutiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DMA",
                Nombre = "Dominica",
                Nacionalidad = "Dominiques",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DNK",
                Nombre = "Dinamarca",
                Nacionalidad = "Danesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DOM",
                Nombre = "Republica Dominicana",
                Nacionalidad = "Dominicana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "DZA",
                Nombre = "Algeria",
                Nacionalidad = "Algeriana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ECU",
                Nombre = "Ecuador",
                Nacionalidad = "Ecuatoriana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "EGY",
                Nombre = "Egipto",
                Nacionalidad = "Egipcia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ERI",
                Nombre = "Eritrea",
                Nacionalidad = "Eritrea",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ESH",
                Nombre = "Sahara Occidental",
                Nacionalidad = "Sahauri",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ESP",
                Nombre = "España",
                Nacionalidad = "Española",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "EST",
                Nombre = "Estonia",
                Nacionalidad = "Estonia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ETH",
                Nombre = "Etiopia",
                Nacionalidad = "Etiope",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "FIN",
                Nombre = "Finlandia",
                Nacionalidad = "Finlandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "FJI",
                Nombre = "Islas de Fiji",
                Nacionalidad = "Fijena",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "FLK",
                Nombre = "Islas Malvinas",
                Nacionalidad = "Kelpers",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "FRA",
                Nombre = "Francia",
                Nacionalidad = "Francesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "FRO",
                Nombre = "Islas Faroe",
                Nacionalidad = "Feroesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GAB",
                Nombre = "Gabon",
                Nacionalidad = "Gabona",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GBR",
                Nombre = "Reino Unido",
                Nacionalidad = "Britanica",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GEO",
                Nombre = "Georgia",
                Nacionalidad = "Georgiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GHA",
                Nombre = "Ghana",
                Nacionalidad = "Ghanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GIB",
                Nombre = "Gibraltar",
                Nacionalidad = "Gibraltareña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GIN",
                Nombre = "Guinea",
                Nacionalidad = "Guinesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GLP",
                Nombre = "Guadeloupe",
                Nacionalidad = "Francesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GMB",
                Nombre = "Gambiana",
                Nacionalidad = "Gambiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GNB",
                Nombre = "Guinea-Bissau",
                Nacionalidad = "Bissauguineana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GNQ",
                Nombre = "Guinea Ecuatorial",
                Nacionalidad = "Ecuatoguineana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GRC",
                Nombre = "Grecia",
                Nacionalidad = "Griega",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GRD",
                Nombre = "Granada",
                Nacionalidad = "Granadeña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GRL",
                Nombre = "Groenlandia",
                Nacionalidad = "Groenlandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GTM",
                Nombre = "Guatemala",
                Nacionalidad = "Guatemalteca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GUF",
                Nombre = "Guyana Francesa",
                Nacionalidad = "Francoguyanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GUM",
                Nombre = "Guam",
                Nacionalidad = "Guamesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "GUY",
                Nombre = "Guyana",
                Nacionalidad = "Guyanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "HKG",
                Nombre = "Hong Kong",
                Nacionalidad = "Hongkonesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "HND",
                Nombre = "Honduras",
                Nacionalidad = "Hondureña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "HRV",
                Nombre = "Croacia",
                Nacionalidad = "Croata",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "HTI",
                Nombre = "Haiti",
                Nacionalidad = "Haitiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "HUN",
                Nombre = "Hungria",
                Nacionalidad = "Hungara",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IDN",
                Nombre = "Indonesia",
                Nacionalidad = "Indonesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IND",
                Nombre = "India",
                Nacionalidad = "India",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IOT",
                Nombre = "Territorio Britanico del Oceano Indico",
                Nacionalidad = "Chaguense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IRL",
                Nombre = "Irlanda",
                Nacionalidad = "Irlandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IRN",
                Nombre = "Iran",
                Nacionalidad = "Irani",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "IRQ",
                Nombre = "Iraq",
                Nacionalidad = "Iraqui",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ISL",
                Nombre = "Islandia",
                Nacionalidad = "Islandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ISR",
                Nombre = "Israel",
                Nacionalidad = "Israelita",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ITA",
                Nombre = "Italia",
                Nacionalidad = "Italiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "JAM",
                Nombre = "Jamaica",
                Nacionalidad = "Jamaiquino",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "JOR",
                Nombre = "Jordania",
                Nacionalidad = "Jordana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "JPN",
                Nombre = "Japon",
                Nacionalidad = "Japonesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KAZ",
                Nombre = "Kazakstan",
                Nacionalidad = "Kazako",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KEN",
                Nombre = "Kenia",
                Nacionalidad = "Keniana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KGZ",
                Nombre = "Kirguistan",
                Nacionalidad = "Kiguiso",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KHM",
                Nombre = "Camboya",
                Nacionalidad = "Camboyana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KIR",
                Nombre = "Kiribati",
                Nacionalidad = "Kiribatiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KNA",
                Nombre = "San Cristobal y Nieves",
                Nacionalidad = "Sancristobaleña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KOR",
                Nombre = "Republica de Corea",
                Nacionalidad = "Coreana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "KWT",
                Nombre = "Kuwait",
                Nacionalidad = "Kuwaiti",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LAO",
                Nombre = "Laos",
                Nacionalidad = "Laosiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LBN",
                Nombre = "Libano",
                Nacionalidad = "Libanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LBR",
                Nombre = "Liberia",
                Nacionalidad = "Liberiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LBY",
                Nombre = "Libia",
                Nacionalidad = "Libica",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LCA",
                Nombre = "Santa Lucia",
                Nacionalidad = "Santaluciana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LIE",
                Nombre = "Liechtenstein",
                Nacionalidad = "Liechtensteiniana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LKA",
                Nombre = "Sri Lanka",
                Nacionalidad = "Sri Lanka",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LSO",
                Nombre = "Lesotho",
                Nacionalidad = "Lesothensa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LTU",
                Nombre = "Lituania",
                Nacionalidad = "Lituana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LUX",
                Nombre = "Luxemburgo",
                Nacionalidad = "Luxemburguesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "LVA",
                Nombre = "Letonia",
                Nacionalidad = "Leton",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MAC",
                Nombre = "Macao",
                Nacionalidad = "Macaense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MAR",
                Nombre = "Marruecos",
                Nacionalidad = "Marroqui",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MCO",
                Nombre = "Monaco",
                Nacionalidad = "Monaco",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MDA",
                Nombre = "Moldavia",
                Nacionalidad = "Moldava",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MDG",
                Nombre = "Madagascar",
                Nacionalidad = "Malgache",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MDV",
                Nombre = "Maldivas",
                Nacionalidad = "Maldiva",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MEX",
                Nombre = "Mexico",
                Nacionalidad = "Mexicana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MHL",
                Nombre = "Islas Marshall",
                Nacionalidad = "Marshalesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MKD",
                Nombre = "Macedonia",
                Nacionalidad = "Macedonia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MLI",
                Nombre = "Mali",
                Nacionalidad = "Mali",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MLT",
                Nombre = "Malta",
                Nacionalidad = "Maltesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MMR",
                Nombre = "Birmania",
                Nacionalidad = "Birmana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MNG",
                Nombre = "Mongolia",
                Nacionalidad = "Mongolesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MNP",
                Nombre = "Islas Marianas del Norte",
                Nacionalidad = "Normarianense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MOZ",
                Nombre = "Mozambique",
                Nacionalidad = "Mozambiqueña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MRT",
                Nombre = "Mauritania",
                Nacionalidad = "Mauritana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MSR",
                Nombre = "Montserrat",
                Nacionalidad = "De Montserrat",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MTQ",
                Nombre = "Martinica",
                Nacionalidad = "Martiniqueña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MUS",
                Nombre = "Mauricio",
                Nacionalidad = "Mauriciana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MWI",
                Nombre = "Malawi",
                Nacionalidad = "Malawi",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MYS",
                Nombre = "Malasia",
                Nacionalidad = "Malaya",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "MYT",
                Nombre = "Mayotte",
                Nacionalidad = "Mayotesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NAM",
                Nombre = "Namibia",
                Nacionalidad = "Namibia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NCL",
                Nombre = "Nueva Caledonia",
                Nacionalidad = "Neocaledonia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NER",
                Nombre = "Niger",
                Nacionalidad = "Nigerina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NFK",
                Nombre = "Isla Norfolk",
                Nacionalidad = "Norfolkense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NGA",
                Nombre = "Nigeria",
                Nacionalidad = "Nigeriana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NIC",
                Nombre = "Nicaragua",
                Nacionalidad = "nicaragüense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NIU",
                Nombre = "Niue",
                Nacionalidad = "Niuana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NLD",
                Nombre = "Paises Bajos",
                Nacionalidad = "Neerlandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NOR",
                Nombre = "Noruega",
                Nacionalidad = "Noruega",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NPL",
                Nombre = "Nepal",
                Nacionalidad = "Nepalesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NRU",
                Nombre = "Nauru",
                Nacionalidad = "Nauru",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "NZL",
                Nombre = "Nueva Zelandia",
                Nacionalidad = "Neozelandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "OMN",
                Nombre = "Oman",
                Nacionalidad = "Omana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PAK",
                Nombre = "Pakistan",
                Nacionalidad = "Pakistani",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PAN",
                Nombre = "Panama",
                Nacionalidad = "Panameña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PCN",
                Nombre = "Islas Pitcairn",
                Nacionalidad = "Pitcairnesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PER",
                Nombre = "Peru",
                Nacionalidad = "Peruana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PHL",
                Nombre = "Filipinas",
                Nacionalidad = "Filipina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PLW",
                Nombre = "Palau",
                Nacionalidad = "Palauana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PNG",
                Nombre = "Papua Nueva Guinea",
                Nacionalidad = "Papu Neoguineano",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "POL",
                Nombre = "Polonia",
                Nacionalidad = "Polaca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PRI",
                Nombre = "Puerto Rico",
                Nacionalidad = "Puertorriqueña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PRK",
                Nombre = "Corea del Sur",
                Nacionalidad = "Coreana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PRT",
                Nombre = "Portugal",
                Nacionalidad = "Portuguesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PRY",
                Nombre = "Paraguay",
                Nacionalidad = "Paraguaya",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PSE",
                Nombre = "Palestina",
                Nacionalidad = "Palestina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "PYF",
                Nombre = "Polinesia Francesa",
                Nacionalidad = "Francopolinesia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "QAT",
                Nombre = "Catar",
                Nacionalidad = "Catari",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "REU",
                Nombre = "Runion",
                Nacionalidad = "Reunionesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "RKS",
                Nombre = "Kosovo",
                Nacionalidad = "kosovar",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ROM",
                Nombre = "Rumania",
                Nacionalidad = "Rumana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "RUS",
                Nombre = "Rusia",
                Nacionalidad = "Rusa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "RWA",
                Nombre = "Ruanda",
                Nacionalidad = "Ruandes",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SAU",
                Nombre = "Arabia Saudita",
                Nacionalidad = "Saudi",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SCT",
                Nombre = "ESCOCIA",
                Nacionalidad = "Escocesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SDN",
                Nombre = "Sudan",
                Nacionalidad = "Sudanesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SEN",
                Nombre = "Senegal",
                Nacionalidad = "sebegalesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SGP",
                Nombre = "Singapur",
                Nacionalidad = "Singapurense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SHN",
                Nombre = "Santa Helena",
                Nacionalidad = "Santahelena",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SLB",
                Nombre = "Islas Salomon",
                Nacionalidad = "Salomonense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SLE",
                Nombre = "Sierra Leona",
                Nacionalidad = "Leonesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SLV",
                Nombre = "Salvador",
                Nacionalidad = "Salvadoreña",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SMR",
                Nombre = "San Marino",
                Nacionalidad = "San Marino",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SOM",
                Nombre = "Somalia",
                Nacionalidad = "Somalia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SPM",
                Nombre = "San Pedro y Miquelon",
                Nacionalidad = "San Pedrina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SRB",
                Nombre = "Serbia",
                Nacionalidad = "Serbia",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "STP",
                Nombre = "Santo Tome y Principe",
                Nacionalidad = "Santotomense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SUR",
                Nombre = "Surinam",
                Nacionalidad = "Surinamesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SVK",
                Nombre = "Eslovaquia",
                Nacionalidad = "Eslovaca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SVN",
                Nombre = "Eslovenia",
                Nacionalidad = "Eslovena",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SWE",
                Nombre = "Suecia",
                Nacionalidad = "Sueca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SWZ",
                Nombre = "Swazilandia",
                Nacionalidad = "Suazi",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SYC",
                Nombre = "Seychelles",
                Nacionalidad = "Seychelense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "SYR",
                Nombre = "Siria",
                Nacionalidad = "Siria",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TCA",
                Nombre = "Islas Turcas y Caicos",
                Nacionalidad = "Turcocainesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TCD",
                Nombre = "Chad",
                Nacionalidad = "Chadiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TGO",
                Nombre = "Togo",
                Nacionalidad = "Togolesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "THA",
                Nombre = "Tailandia",
                Nacionalidad = "Tailandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TJK",
                Nombre = "Tayikistan",
                Nacionalidad = "Tayika",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TKL",
                Nombre = "Tokelau",
                Nacionalidad = "Tokelauana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TKM",
                Nombre = "Turkmenistan",
                Nacionalidad = "Turcomana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TMP",
                Nombre = "Timor Leste",
                Nacionalidad = "Timorense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TON",
                Nombre = "Tonga",
                Nacionalidad = "Tonga",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TTO",
                Nombre = "Trinidad y Tobago",
                Nacionalidad = "Trinitense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TUN",
                Nombre = "Tunez",
                Nacionalidad = "Tunecina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TUR",
                Nombre = "Turquia",
                Nacionalidad = "Turca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TUV",
                Nombre = "Tuvalu",
                Nacionalidad = "Tuvaluana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TWN",
                Nombre = "China/Taiwan",
                Nacionalidad = "China/Taiwan",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "TZA",
                Nombre = "Tanzania",
                Nacionalidad = "Tanzana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "UGA",
                Nombre = "Uganda",
                Nacionalidad = "Ugandesa",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "UKR",
                Nombre = "Ucrania",
                Nacionalidad = "Ucraniana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "URY",
                Nombre = "Uruguay",
                Nacionalidad = "Uruguaya",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "USA",
                Nombre = "Estados Unidos",
                Nacionalidad = "Estadounidense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "UZB",
                Nombre = "Uzbekistan",
                Nacionalidad = "Uzbeca",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VAT",
                Nombre = "Ciudad del Vaticano",
                Nacionalidad = "Vaticana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VCT",
                Nombre = "San Vicente y Granadinas",
                Nacionalidad = "Sanvicentina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VEN",
                Nombre = "Venezuela",
                Nacionalidad = "Venezolana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VGB",
                Nombre = "Islas Virgenes",
                Nacionalidad = "Virginense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VI",
                Nombre = "Vicentina",
                Nacionalidad = "Vicentina",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VIR",
                Nombre = "Islas Virgenes",
                Nacionalidad = "Virginense Britanica",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VNM",
                Nombre = "Vietnam",
                Nacionalidad = "Vietnamita",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "VUT",
                Nombre = "Vanuatu",
                Nacionalidad = "Vanuatuenense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "WLF",
                Nombre = "Wallis and Futuna",
                Nacionalidad = "Walisiana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "WSM",
                Nombre = "Samoa",
                Nacionalidad = "Samoana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "YEM",
                Nombre = "Yemen",
                Nacionalidad = "Yemen",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "YUG",
                Nombre = "Yugoslavia",
                Nacionalidad = "Yugoslava",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ZAF",
                Nombre = "Sudafrica",
                Nacionalidad = "Sudafricana",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ZMB",
                Nombre = "Zambia",
                Nacionalidad = "Zambio",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            },
            new()
            {
                Id = "ZWE",
                Nombre = "Zimbabue",
                Nacionalidad = "Zimbabuense",
                FechaCreacion = DateTime.Parse("2022-10-10"),
                FechaModificacion = DateTime.Parse("2022-10-10")
            }
        };

        builder.Entity<Pais>().HasData(countries);
    }
}