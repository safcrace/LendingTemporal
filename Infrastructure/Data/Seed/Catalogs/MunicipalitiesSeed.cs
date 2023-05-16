using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed.Catalogs;

public static class MunicipalitiesSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var municipalities = new Municipio[]
        {
            new()
            {
                Id = "1001",
                DepartamentoId = 10,
                Nombre = "Mazatenango",
                Descripcion = "Mazatenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1002",
                DepartamentoId = 10,
                Nombre = "Cuyotenango",
                Descripcion = "Cuyotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1003",
                DepartamentoId = 10,
                Nombre = "San Francisco Zapotitlán",
                Descripcion = "San Francisco Zapotitlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1004",
                DepartamentoId = 10,
                Nombre = "San Bernardino",
                Descripcion = "San Bernardino",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1005",
                DepartamentoId = 10,
                Nombre = "San José el Ídolo",
                Descripcion = "San José el Ídolo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1006",
                DepartamentoId = 10,
                Nombre = "Santo Domingo Suchitepéquez",
                Descripcion = "Santo Domingo Suchitepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1007",
                DepartamentoId = 10,
                Nombre = "San Lorenzo",
                Descripcion = "San Lorenzo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1008",
                DepartamentoId = 10,
                Nombre = "Samayac",
                Descripcion = "Samayac",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1009",
                DepartamentoId = 10,
                Nombre = "San Pablo Jocopilas",
                Descripcion = "San Pablo Jocopilas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "101",
                DepartamentoId = 1,
                Nombre = "Guatemala",
                Descripcion = "Guatemala",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1010",
                DepartamentoId = 10,
                Nombre = "San Antonio Suchitepéquez",
                Descripcion = "San Antonio Suchitepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1011",
                DepartamentoId = 10,
                Nombre = "San Miguel Panán",
                Descripcion = "San Miguel Panán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1012",
                DepartamentoId = 10,
                Nombre = "San Gabriel",
                Descripcion = "San Gabriel",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1013",
                DepartamentoId = 10,
                Nombre = "Chicacao",
                Descripcion = "Chicacao",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1014",
                DepartamentoId = 10,
                Nombre = "Patulul",
                Descripcion = "Patulul",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1015",
                DepartamentoId = 10,
                Nombre = "Santa Bárbara",
                Descripcion = "Santa Bárbara",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1016",
                DepartamentoId = 10,
                Nombre = "San Juan Bautista",
                Descripcion = "San Juan Bautista",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1017",
                DepartamentoId = 10,
                Nombre = "Santo Tomas la Unión",
                Descripcion = "Santo Tomas la Unión",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1018",
                DepartamentoId = 10,
                Nombre = "Zunilito",
                Descripcion = "Zunilito",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1019",
                DepartamentoId = 10,
                Nombre = "Pueblo Nuevo",
                Descripcion = "Pueblo Nuevo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "102",
                DepartamentoId = 1,
                Nombre = "Santa Catarina Pinula",
                Descripcion = "Santa Catarina Pinula",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1020",
                DepartamentoId = 10,
                Nombre = "Río Bravo",
                Descripcion = "Río Bravo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1021",
                DepartamentoId = 10,
                Nombre = "San José La Máquina",
                Descripcion = "San José La Máquina",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "103",
                DepartamentoId = 1,
                Nombre = "San José Pinula",
                Descripcion = "San José Pinula",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "104",
                DepartamentoId = 1,
                Nombre = "San José del Golfo",
                Descripcion = "San José del Golfo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "105",
                DepartamentoId = 1,
                Nombre = "Palencia",
                Descripcion = "Palencia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "106",
                DepartamentoId = 1,
                Nombre = "Chinautla",
                Descripcion = "Chinautla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "107",
                DepartamentoId = 1,
                Nombre = "San Pedro Ayampuc",
                Descripcion = "San Pedro Ayampuc",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "108",
                DepartamentoId = 1,
                Nombre = "Mixco",
                Descripcion = "Mixco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "109",
                DepartamentoId = 1,
                Nombre = "San Pedro Sacatepéquez",
                Descripcion = "San Pedro Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "110",
                DepartamentoId = 1,
                Nombre = "San Juan Sacatepéquez",
                Descripcion = "San Juan Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1101",
                DepartamentoId = 11,
                Nombre = "Retalhuleu",
                Descripcion = "Retalhuleu",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1102",
                DepartamentoId = 11,
                Nombre = "San Sebastián",
                Descripcion = "San Sebastián",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1103",
                DepartamentoId = 11,
                Nombre = "Santa Cruz Muluá",
                Descripcion = "Santa Cruz Muluá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1104",
                DepartamentoId = 11,
                Nombre = "San Martín Zapotitlán",
                Descripcion = "San Martín Zapotitlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1105",
                DepartamentoId = 11,
                Nombre = "San Felipe",
                Descripcion = "San Felipe",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1106",
                DepartamentoId = 11,
                Nombre = "San Andrés Villa Seca",
                Descripcion = "San Andrés Villa Seca",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1107",
                DepartamentoId = 11,
                Nombre = "Champerico",
                Descripcion = "Champerico",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1108",
                DepartamentoId = 11,
                Nombre = "Nuevo San Carlos",
                Descripcion = "Nuevo San Carlos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1109",
                DepartamentoId = 11,
                Nombre = "El Asintal",
                Descripcion = "El Asintal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "111",
                DepartamentoId = 1,
                Nombre = "San Raymundo",
                Descripcion = "San Raymundo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "112",
                DepartamentoId = 1,
                Nombre = "Chuarrancho",
                Descripcion = "Chuarrancho",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "113",
                DepartamentoId = 1,
                Nombre = "Fraijanes",
                Descripcion = "Fraijanes",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "114",
                DepartamentoId = 1,
                Nombre = "Amatitlán",
                Descripcion = "Amatitlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "115",
                DepartamentoId = 1,
                Nombre = "Villa Nueva",
                Descripcion = "Villa Nueva",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "116",
                DepartamentoId = 1,
                Nombre = "Villa Canales",
                Descripcion = "Villa Canales",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "117",
                DepartamentoId = 1,
                Nombre = "Petapa",
                Descripcion = "Petapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1201",
                DepartamentoId = 12,
                Nombre = "San Marcos",
                Descripcion = "San Marcos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1202",
                DepartamentoId = 12,
                Nombre = "San Pedro Sacatepéquez",
                Descripcion = "San Pedro Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1203",
                DepartamentoId = 12,
                Nombre = "San Antonio Sacatepéquez",
                Descripcion = "San Antonio Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1204",
                DepartamentoId = 12,
                Nombre = "Comitancillo",
                Descripcion = "Comitancillo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1205",
                DepartamentoId = 12,
                Nombre = "San Miguel Ixtahuacán",
                Descripcion = "San Miguel Ixtahuacán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1206",
                DepartamentoId = 12,
                Nombre = "Concepción Tutuapa",
                Descripcion = "Concepción Tutuapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1207",
                DepartamentoId = 12,
                Nombre = "Tacaná",
                Descripcion = "Tacaná",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1208",
                DepartamentoId = 12,
                Nombre = "Sibinal",
                Descripcion = "Sibinal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1209",
                DepartamentoId = 12,
                Nombre = "Tajumulco",
                Descripcion = "Tajumulco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1210",
                DepartamentoId = 12,
                Nombre = "Tejutla",
                Descripcion = "Tejutla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1211",
                DepartamentoId = 12,
                Nombre = "San Rafael Pie de la Cuesta",
                Descripcion = "San Rafael Pie de la Cuesta",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1212",
                DepartamentoId = 12,
                Nombre = "Nuevo Progreso",
                Descripcion = "Nuevo Progreso",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1213",
                DepartamentoId = 12,
                Nombre = "El Tumbador",
                Descripcion = "El Tumbador",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1214",
                DepartamentoId = 12,
                Nombre = "San José el Rodeo",
                Descripcion = "San José el Rodeo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1215",
                DepartamentoId = 12,
                Nombre = "Malacatán",
                Descripcion = "Malacatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1216",
                DepartamentoId = 12,
                Nombre = "Catarina",
                Descripcion = "Catarina",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1217",
                DepartamentoId = 12,
                Nombre = "Ayutla",
                Descripcion = "Ayutla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1218",
                DepartamentoId = 12,
                Nombre = "Ocós",
                Descripcion = "Ocós",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1219",
                DepartamentoId = 12,
                Nombre = "San Pablo",
                Descripcion = "San Pablo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1220",
                DepartamentoId = 12,
                Nombre = "El Quetzal",
                Descripcion = "El Quetzal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1221",
                DepartamentoId = 12,
                Nombre = "La Reforma",
                Descripcion = "La Reforma",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1222",
                DepartamentoId = 12,
                Nombre = "Pajapita",
                Descripcion = "Pajapita",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1223",
                DepartamentoId = 12,
                Nombre = "Ixchiguán",
                Descripcion = "Ixchiguán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1224",
                DepartamentoId = 12,
                Nombre = "San José Ojetenam",
                Descripcion = "San José Ojetenam",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1225",
                DepartamentoId = 12,
                Nombre = "San Cristóbal Cucho",
                Descripcion = "San Cristóbal Cucho",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1226",
                DepartamentoId = 12,
                Nombre = "Sipacapa",
                Descripcion = "Sipacapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1227",
                DepartamentoId = 12,
                Nombre = "Esquipulas Palo Gordo",
                Descripcion = "Esquipulas Palo Gordo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1228",
                DepartamentoId = 12,
                Nombre = "Río Blanco",
                Descripcion = "Río Blanco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1229",
                DepartamentoId = 12,
                Nombre = "San Lorenzo",
                Descripcion = "San Lorenzo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1230",
                DepartamentoId = 12,
                Nombre = "La Blanca",
                Descripcion = "La Blanca",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1301",
                DepartamentoId = 13,
                Nombre = "Huehuetenango",
                Descripcion = "Huehuetenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1302",
                DepartamentoId = 13,
                Nombre = "Chiantla",
                Descripcion = "Chiantla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1303",
                DepartamentoId = 13,
                Nombre = "Malacatancito",
                Descripcion = "Malacatancito",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1304",
                DepartamentoId = 13,
                Nombre = "Cuilco",
                Descripcion = "Cuilco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1305",
                DepartamentoId = 13,
                Nombre = "Nentón",
                Descripcion = "Nentón",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1306",
                DepartamentoId = 13,
                Nombre = "San Pedro Necta",
                Descripcion = "San Pedro Necta",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1307",
                DepartamentoId = 13,
                Nombre = "Jacaltenango",
                Descripcion = "Jacaltenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1308",
                DepartamentoId = 13,
                Nombre = "San Pedro Soloma",
                Descripcion = "San Pedro Soloma",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1309",
                DepartamentoId = 13,
                Nombre = "San Ildefonso Ixtahuacán",
                Descripcion = "San Ildefonso Ixtahuacán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1310",
                DepartamentoId = 13,
                Nombre = "Santa Bárbara",
                Descripcion = "Santa Bárbara",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1311",
                DepartamentoId = 13,
                Nombre = "La Libertad",
                Descripcion = "La Libertad",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1312",
                DepartamentoId = 13,
                Nombre = "La Democracia",
                Descripcion = "La Democracia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1313",
                DepartamentoId = 13,
                Nombre = "San Miguel Acatán",
                Descripcion = "San Miguel Acatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1314",
                DepartamentoId = 13,
                Nombre = "San Rafael La Independencia",
                Descripcion = "San Rafael La Independencia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1315",
                DepartamentoId = 13,
                Nombre = "Todos Santos Cuchumatán",
                Descripcion = "Todos Santos Cuchumatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1316",
                DepartamentoId = 13,
                Nombre = "San Juan Atitán",
                Descripcion = "San Juan Atitán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1317",
                DepartamentoId = 13,
                Nombre = "Santa Eulalia",
                Descripcion = "Santa Eulalia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1318",
                DepartamentoId = 13,
                Nombre = "San Mateo Ixtatán",
                Descripcion = "San Mateo Ixtatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1319",
                DepartamentoId = 13,
                Nombre = "Colotenango",
                Descripcion = "Colotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1320",
                DepartamentoId = 13,
                Nombre = "San Sebastián Huehuetenango",
                Descripcion = "San Sebastián Huehuetenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1321",
                DepartamentoId = 13,
                Nombre = "Tectitán",
                Descripcion = "Tectitán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1322",
                DepartamentoId = 13,
                Nombre = "Concepción Huista",
                Descripcion = "Concepción Huista",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1323",
                DepartamentoId = 13,
                Nombre = "San Juan Ixcoy",
                Descripcion = "San Juan Ixcoy",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1324",
                DepartamentoId = 13,
                Nombre = "San Antonio Huista",
                Descripcion = "San Antonio Huista",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1325",
                DepartamentoId = 13,
                Nombre = "San Sebastián Coatán",
                Descripcion = "San Sebastián Coatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1326",
                DepartamentoId = 13,
                Nombre = "Santa Cruz Barrillas",
                Descripcion = "Santa Cruz Barrillas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1327",
                DepartamentoId = 13,
                Nombre = "Aguacatán",
                Descripcion = "Aguacatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1328",
                DepartamentoId = 13,
                Nombre = "San Rafael Petzal",
                Descripcion = "San Rafael Petzal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1329",
                DepartamentoId = 13,
                Nombre = "San Gaspar Ixchil",
                Descripcion = "San Gaspar Ixchil",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1330",
                DepartamentoId = 13,
                Nombre = "Santiago Chimaltenango",
                Descripcion = "Santiago Chimaltenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1331",
                DepartamentoId = 13,
                Nombre = "Santa Ana Huista",
                Descripcion = "Santa Ana Huista",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1332",
                DepartamentoId = 13,
                Nombre = "Unión Cantinil",
                Descripcion = "Unión Cantinil",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1333",
                DepartamentoId = 13,
                Nombre = "Petatán",
                Descripcion = "Petatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1401",
                DepartamentoId = 14,
                Nombre = "Santa Cruz del Quiché",
                Descripcion = "Santa Cruz del Quiché",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1402",
                DepartamentoId = 14,
                Nombre = "Chiché",
                Descripcion = "Chiché",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1403",
                DepartamentoId = 14,
                Nombre = "Chinique",
                Descripcion = "Chinique",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1404",
                DepartamentoId = 14,
                Nombre = "Zacualpa",
                Descripcion = "Zacualpa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1405",
                DepartamentoId = 14,
                Nombre = "Chajul",
                Descripcion = "Chajul",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1406",
                DepartamentoId = 14,
                Nombre = "Santo TomásChichicastenango",
                Descripcion = "Santo TomásChichicastenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1407",
                DepartamentoId = 14,
                Nombre = "Patzité",
                Descripcion = "Patzité",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1408",
                DepartamentoId = 14,
                Nombre = "San Antonio Ilotenango",
                Descripcion = "San Antonio Ilotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1409",
                DepartamentoId = 14,
                Nombre = "San Pedro Jocopilas",
                Descripcion = "San Pedro Jocopilas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1410",
                DepartamentoId = 14,
                Nombre = "Cunén",
                Descripcion = "Cunén",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1411",
                DepartamentoId = 14,
                Nombre = "San Juan Cotzal",
                Descripcion = "San Juan Cotzal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1412",
                DepartamentoId = 14,
                Nombre = "Joyabaj",
                Descripcion = "Joyabaj",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1413",
                DepartamentoId = 14,
                Nombre = "Santa María Nebaj",
                Descripcion = "Santa María Nebaj",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1414",
                DepartamentoId = 14,
                Nombre = "San Andrés Sajcabajá",
                Descripcion = "San Andrés Sajcabajá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1415",
                DepartamentoId = 14,
                Nombre = "San Miguel Uspantán",
                Descripcion = "San Miguel Uspantán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1416",
                DepartamentoId = 14,
                Nombre = "Sacapulas",
                Descripcion = "Sacapulas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1417",
                DepartamentoId = 14,
                Nombre = "San Bartolomé Jocotenango",
                Descripcion = "San Bartolomé Jocotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1418",
                DepartamentoId = 14,
                Nombre = "Canillá",
                Descripcion = "Canillá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1419",
                DepartamentoId = 14,
                Nombre = "Chicamán",
                Descripcion = "Chicamán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1420",
                DepartamentoId = 14,
                Nombre = "Ixcán",
                Descripcion = "Ixcán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1421",
                DepartamentoId = 14,
                Nombre = "Pachalum",
                Descripcion = "Pachalum",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1501",
                DepartamentoId = 15,
                Nombre = "Salamá",
                Descripcion = "Salamá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1502",
                DepartamentoId = 15,
                Nombre = "San Miguel Chicaj",
                Descripcion = "San Miguel Chicaj",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1503",
                DepartamentoId = 15,
                Nombre = "Rabinal",
                Descripcion = "Rabinal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1504",
                DepartamentoId = 15,
                Nombre = "Cubulco",
                Descripcion = "Cubulco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1505",
                DepartamentoId = 15,
                Nombre = "Granados",
                Descripcion = "Granados",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1506",
                DepartamentoId = 15,
                Nombre = "El Chol",
                Descripcion = "El Chol",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1507",
                DepartamentoId = 15,
                Nombre = "San Jerónimo",
                Descripcion = "San Jerónimo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1508",
                DepartamentoId = 15,
                Nombre = "Purulhá",
                Descripcion = "Purulhá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1601",
                DepartamentoId = 16,
                Nombre = "Cobán",
                Descripcion = "Cobán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1602",
                DepartamentoId = 16,
                Nombre = "Santa Cruz Verapaz",
                Descripcion = "Santa Cruz Verapaz",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1603",
                DepartamentoId = 16,
                Nombre = "San Cristóbal Verapaz",
                Descripcion = "San Cristóbal Verapaz",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1604",
                DepartamentoId = 16,
                Nombre = "Tactic",
                Descripcion = "Tactic",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1605",
                DepartamentoId = 16,
                Nombre = "Tamahú",
                Descripcion = "Tamahú",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1606",
                DepartamentoId = 16,
                Nombre = "Tucurú",
                Descripcion = "Tucurú",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1607",
                DepartamentoId = 16,
                Nombre = "Panzós",
                Descripcion = "Panzós",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1608",
                DepartamentoId = 16,
                Nombre = "Senahú",
                Descripcion = "Senahú",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1609",
                DepartamentoId = 16,
                Nombre = "San Pedro Carchá",
                Descripcion = "San Pedro Carchá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1610",
                DepartamentoId = 16,
                Nombre = "San Juan Chamelco",
                Descripcion = "San Juan Chamelco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1611",
                DepartamentoId = 16,
                Nombre = "San Agustín Lanquín",
                Descripcion = "San Agustín Lanquín",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1612",
                DepartamentoId = 16,
                Nombre = "Santa María Cahabón",
                Descripcion = "Santa María Cahabón",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1613",
                DepartamentoId = 16,
                Nombre = "Chisec",
                Descripcion = "Chisec",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1614",
                DepartamentoId = 16,
                Nombre = "Chahal",
                Descripcion = "Chahal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1615",
                DepartamentoId = 16,
                Nombre = "Fray Bartolomé de Las Casas",
                Descripcion = "Fray Bartolomé de Las Casas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1616",
                DepartamentoId = 16,
                Nombre = "Santa Catarina La Tinta",
                Descripcion = "Santa Catarina La Tinta",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1617",
                DepartamentoId = 16,
                Nombre = "Raxruhá",
                Descripcion = "Raxruhá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1701",
                DepartamentoId = 17,
                Nombre = "Flores",
                Descripcion = "Flores",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1702",
                DepartamentoId = 17,
                Nombre = "San José",
                Descripcion = "San José",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1703",
                DepartamentoId = 17,
                Nombre = "San Benito",
                Descripcion = "San Benito",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1704",
                DepartamentoId = 17,
                Nombre = "San Andrés",
                Descripcion = "San Andrés",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1705",
                DepartamentoId = 17,
                Nombre = "La Libertad",
                Descripcion = "La Libertad",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1706",
                DepartamentoId = 17,
                Nombre = "San Francisco",
                Descripcion = "San Francisco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1707",
                DepartamentoId = 17,
                Nombre = "Santa Ana",
                Descripcion = "Santa Ana",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1708",
                DepartamentoId = 17,
                Nombre = "Dolores",
                Descripcion = "Dolores",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1709",
                DepartamentoId = 17,
                Nombre = "San Luis",
                Descripcion = "San Luis",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1710",
                DepartamentoId = 17,
                Nombre = "Sayaxché",
                Descripcion = "Sayaxché",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1711",
                DepartamentoId = 17,
                Nombre = "Melchor de Mencos",
                Descripcion = "Melchor de Mencos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1712",
                DepartamentoId = 17,
                Nombre = "Poptún",
                Descripcion = "Poptún",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1713",
                DepartamentoId = 17,
                Nombre = "Las Cruces",
                Descripcion = "Las Cruces",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1714",
                DepartamentoId = 17,
                Nombre = "El Chal",
                Descripcion = "El Chal",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1801",
                DepartamentoId = 18,
                Nombre = "Puerto Barrios",
                Descripcion = "Puerto Barrios",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1802",
                DepartamentoId = 18,
                Nombre = "Livingston",
                Descripcion = "Livingston",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1803",
                DepartamentoId = 18,
                Nombre = "El Estor",
                Descripcion = "El Estor",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1804",
                DepartamentoId = 18,
                Nombre = "Morales",
                Descripcion = "Morales",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1805",
                DepartamentoId = 18,
                Nombre = "Los Amates",
                Descripcion = "Los Amates",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1901",
                DepartamentoId = 19,
                Nombre = "Zacapa",
                Descripcion = "Zacapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1902",
                DepartamentoId = 19,
                Nombre = "Estanzuela",
                Descripcion = "Estanzuela",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1903",
                DepartamentoId = 19,
                Nombre = "Río Hondo",
                Descripcion = "Río Hondo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1904",
                DepartamentoId = 19,
                Nombre = "Gualán",
                Descripcion = "Gualán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1905",
                DepartamentoId = 19,
                Nombre = "Teculután",
                Descripcion = "Teculután",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1906",
                DepartamentoId = 19,
                Nombre = "Usumatlán",
                Descripcion = "Usumatlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1907",
                DepartamentoId = 19,
                Nombre = "Caba±as",
                Descripcion = "Caba±as",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1908",
                DepartamentoId = 19,
                Nombre = "San Diego",
                Descripcion = "San Diego",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1909",
                DepartamentoId = 19,
                Nombre = "La Unión",
                Descripcion = "La Unión",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1910",
                DepartamentoId = 19,
                Nombre = "Huité",
                Descripcion = "Huité",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "1911",
                DepartamentoId = 19,
                Nombre = "San Jorge",
                Descripcion = "San Jorge",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2001",
                DepartamentoId = 20,
                Nombre = "Chiquimula",
                Descripcion = "Chiquimula",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2002",
                DepartamentoId = 20,
                Nombre = "San José La Arada",
                Descripcion = "San José La Arada",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2003",
                DepartamentoId = 20,
                Nombre = "San Juan Ermita",
                Descripcion = "San Juan Ermita",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2004",
                DepartamentoId = 20,
                Nombre = "Jocotán",
                Descripcion = "Jocotán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2005",
                DepartamentoId = 20,
                Nombre = "Camotán",
                Descripcion = "Camotán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2006",
                DepartamentoId = 20,
                Nombre = "Olopa",
                Descripcion = "Olopa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2007",
                DepartamentoId = 20,
                Nombre = "Esquipulas",
                Descripcion = "Esquipulas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2008",
                DepartamentoId = 20,
                Nombre = "Concepción las Minas",
                Descripcion = "Concepción las Minas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2009",
                DepartamentoId = 20,
                Nombre = "Quezaltepeque",
                Descripcion = "Quezaltepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "201",
                DepartamentoId = 2,
                Nombre = "Guastatoya",
                Descripcion = "Guastatoya",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2010",
                DepartamentoId = 20,
                Nombre = "San Jacinto",
                Descripcion = "San Jacinto",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2011",
                DepartamentoId = 20,
                Nombre = "Ipala",
                Descripcion = "Ipala",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "202",
                DepartamentoId = 2,
                Nombre = "Morazán",
                Descripcion = "Morazán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "203",
                DepartamentoId = 2,
                Nombre = "San Agustín Acasaguastlán",
                Descripcion = "San Agustín Acasaguastlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "204",
                DepartamentoId = 2,
                Nombre = "San Cristóbal Acasaguastlán",
                Descripcion = "San Cristóbal Acasaguastlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "205",
                DepartamentoId = 2,
                Nombre = "El Jícaro",
                Descripcion = "El Jícaro",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "206",
                DepartamentoId = 2,
                Nombre = "Sansare",
                Descripcion = "Sansare",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "207",
                DepartamentoId = 2,
                Nombre = "Sanarate",
                Descripcion = "Sanarate",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "208",
                DepartamentoId = 2,
                Nombre = "San Antonio la Paz",
                Descripcion = "San Antonio la Paz",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2101",
                DepartamentoId = 21,
                Nombre = "Jalapa",
                Descripcion = "Jalapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2102",
                DepartamentoId = 21,
                Nombre = "San Pedro Pinula",
                Descripcion = "San Pedro Pinula",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2103",
                DepartamentoId = 21,
                Nombre = "San Luis Jilotepeque",
                Descripcion = "San Luis Jilotepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2104",
                DepartamentoId = 21,
                Nombre = "San Manuel Chaparrón",
                Descripcion = "San Manuel Chaparrón",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2105",
                DepartamentoId = 21,
                Nombre = "San Carlos Alzatate",
                Descripcion = "San Carlos Alzatate",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2106",
                DepartamentoId = 21,
                Nombre = "Monjas",
                Descripcion = "Monjas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2107",
                DepartamentoId = 21,
                Nombre = "Mataquescuintla",
                Descripcion = "Mataquescuintla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2201",
                DepartamentoId = 22,
                Nombre = "Jutiapa",
                Descripcion = "Jutiapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2202",
                DepartamentoId = 22,
                Nombre = "El Progreso",
                Descripcion = "El Progreso",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2203",
                DepartamentoId = 22,
                Nombre = "Santa Catarina Mita",
                Descripcion = "Santa Catarina Mita",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2204",
                DepartamentoId = 22,
                Nombre = "Agua Blanca",
                Descripcion = "Agua Blanca",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2205",
                DepartamentoId = 22,
                Nombre = "Asunción Mita",
                Descripcion = "Asunción Mita",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2206",
                DepartamentoId = 22,
                Nombre = "Yupiltepeque",
                Descripcion = "Yupiltepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2207",
                DepartamentoId = 22,
                Nombre = "Atescatempa",
                Descripcion = "Atescatempa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2208",
                DepartamentoId = 22,
                Nombre = "Jerez",
                Descripcion = "Jerez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2209",
                DepartamentoId = 22,
                Nombre = "El Adelanto",
                Descripcion = "El Adelanto",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2210",
                DepartamentoId = 22,
                Nombre = "Zapotitlán",
                Descripcion = "Zapotitlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2211",
                DepartamentoId = 22,
                Nombre = "Comapa",
                Descripcion = "Comapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2212",
                DepartamentoId = 22,
                Nombre = "Jalpatagua",
                Descripcion = "Jalpatagua",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2213",
                DepartamentoId = 22,
                Nombre = "Conguaco",
                Descripcion = "Conguaco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2214",
                DepartamentoId = 22,
                Nombre = "Moyuta",
                Descripcion = "Moyuta",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2215",
                DepartamentoId = 22,
                Nombre = "Pasaco",
                Descripcion = "Pasaco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2216",
                DepartamentoId = 22,
                Nombre = "San José Acatempa",
                Descripcion = "San José Acatempa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "2217",
                DepartamentoId = 22,
                Nombre = "Quesada",
                Descripcion = "Quesada",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "301",
                DepartamentoId = 3,
                Nombre = "Antigua Guatemala",
                Descripcion = "Antigua Guatemala",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "302",
                DepartamentoId = 3,
                Nombre = "Jocotenango",
                Descripcion = "Jocotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "303",
                DepartamentoId = 3,
                Nombre = "Pastores",
                Descripcion = "Pastores",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "304",
                DepartamentoId = 3,
                Nombre = "Sumpango",
                Descripcion = "Sumpango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "305",
                DepartamentoId = 3,
                Nombre = "Santo Domingo Xenacoj",
                Descripcion = "Santo Domingo Xenacoj",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "306",
                DepartamentoId = 3,
                Nombre = "Santiago Sacatepéquez",
                Descripcion = "Santiago Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "307",
                DepartamentoId = 3,
                Nombre = "San Bartolomé Milpas Altas",
                Descripcion = "San Bartolomé Milpas Altas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "308",
                DepartamentoId = 3,
                Nombre = "San Lucas Sacatepéquez",
                Descripcion = "San Lucas Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "309",
                DepartamentoId = 3,
                Nombre = "Santa Lucía Milpas Altas",
                Descripcion = "Santa Lucía Milpas Altas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "310",
                DepartamentoId = 3,
                Nombre = "Magdalena Milpas Altas",
                Descripcion = "Magdalena Milpas Altas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "311",
                DepartamentoId = 3,
                Nombre = "Santa María de Jesús",
                Descripcion = "Santa María de Jesús",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "312",
                DepartamentoId = 3,
                Nombre = "Ciudad Vieja",
                Descripcion = "Ciudad Vieja",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "313",
                DepartamentoId = 3,
                Nombre = "San Miguel Due±as",
                Descripcion = "San Miguel Due±as",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "314",
                DepartamentoId = 3,
                Nombre = "San Juan Alotenango",
                Descripcion = "San Juan Alotenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "315",
                DepartamentoId = 3,
                Nombre = "San Antonio Aguas Calientes",
                Descripcion = "San Antonio Aguas Calientes",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "316",
                DepartamentoId = 3,
                Nombre = "Santa Catarina Barahona",
                Descripcion = "Santa Catarina Barahona",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "401",
                DepartamentoId = 4,
                Nombre = "Chimaltenango",
                Descripcion = "Chimaltenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "402",
                DepartamentoId = 4,
                Nombre = "San José  Poaquil",
                Descripcion = "San José  Poaquil",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "403",
                DepartamentoId = 4,
                Nombre = "San Martín Jilotepeque",
                Descripcion = "San Martín Jilotepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "404",
                DepartamentoId = 4,
                Nombre = "Comalapa",
                Descripcion = "Comalapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "405",
                DepartamentoId = 4,
                Nombre = "Santa Apolonia",
                Descripcion = "Santa Apolonia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "406",
                DepartamentoId = 4,
                Nombre = "Tecpán Guatemala",
                Descripcion = "Tecpán Guatemala",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "407",
                DepartamentoId = 4,
                Nombre = "Patzún",
                Descripcion = "Patzún",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "408",
                DepartamentoId = 4,
                Nombre = "San Miguel Pochuta",
                Descripcion = "San Miguel Pochuta",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "409",
                DepartamentoId = 4,
                Nombre = "Patzicía",
                Descripcion = "Patzicía",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "410",
                DepartamentoId = 4,
                Nombre = "Santa Cruz Balanyá",
                Descripcion = "Santa Cruz Balanyá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "411",
                DepartamentoId = 4,
                Nombre = "Acatenango",
                Descripcion = "Acatenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "412",
                DepartamentoId = 4,
                Nombre = "San Pedro Yepocapa",
                Descripcion = "San Pedro Yepocapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "413",
                DepartamentoId = 4,
                Nombre = "San Andrés Itzapa",
                Descripcion = "San Andrés Itzapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "414",
                DepartamentoId = 4,
                Nombre = "Parramos",
                Descripcion = "Parramos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "415",
                DepartamentoId = 4,
                Nombre = "Zaragoza",
                Descripcion = "Zaragoza",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "416",
                DepartamentoId = 4,
                Nombre = "El Tejar",
                Descripcion = "El Tejar",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "501",
                DepartamentoId = 5,
                Nombre = "Escuintla",
                Descripcion = "Escuintla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "502",
                DepartamentoId = 5,
                Nombre = "Santa Lucía Cotzumalguapa",
                Descripcion = "Santa Lucía Cotzumalguapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "503",
                DepartamentoId = 5,
                Nombre = "La Democracia",
                Descripcion = "La Democracia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "504",
                DepartamentoId = 5,
                Nombre = "Siquinalá",
                Descripcion = "Siquinalá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "505",
                DepartamentoId = 5,
                Nombre = "Masagua",
                Descripcion = "Masagua",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "506",
                DepartamentoId = 5,
                Nombre = "Tiquisate",
                Descripcion = "Tiquisate",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "507",
                DepartamentoId = 5,
                Nombre = "La Gomera",
                Descripcion = "La Gomera",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "508",
                DepartamentoId = 5,
                Nombre = "Guanagazapa",
                Descripcion = "Guanagazapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "509",
                DepartamentoId = 5,
                Nombre = "San José",
                Descripcion = "San José",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "510",
                DepartamentoId = 5,
                Nombre = "Iztapa",
                Descripcion = "Iztapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "511",
                DepartamentoId = 5,
                Nombre = "Palín",
                Descripcion = "Palín",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "512",
                DepartamentoId = 5,
                Nombre = "San Vicente Pacaya",
                Descripcion = "San Vicente Pacaya",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "513",
                DepartamentoId = 5,
                Nombre = "Nueva Concepción",
                Descripcion = "Nueva Concepción",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "514",
                DepartamentoId = 5,
                Nombre = "Sipacate",
                Descripcion = "Sipacate",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "601",
                DepartamentoId = 6,
                Nombre = "Cuilapa",
                Descripcion = "Cuilapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "602",
                DepartamentoId = 6,
                Nombre = "Barberena",
                Descripcion = "Barberena",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "603",
                DepartamentoId = 6,
                Nombre = "Santa Rosa de Lima",
                Descripcion = "Santa Rosa de Lima",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "604",
                DepartamentoId = 6,
                Nombre = "Casillas",
                Descripcion = "Casillas",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "605",
                DepartamentoId = 6,
                Nombre = "San Rafael Las Flores",
                Descripcion = "San Rafael Las Flores",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "606",
                DepartamentoId = 6,
                Nombre = "Oratorio",
                Descripcion = "Oratorio",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "607",
                DepartamentoId = 6,
                Nombre = "San Juan Tecuaco",
                Descripcion = "San Juan Tecuaco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "608",
                DepartamentoId = 6,
                Nombre = "Chiquimulilla",
                Descripcion = "Chiquimulilla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "609",
                DepartamentoId = 6,
                Nombre = "Taxisco",
                Descripcion = "Taxisco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "610",
                DepartamentoId = 6,
                Nombre = "Santa María Ixhuatán",
                Descripcion = "Santa María Ixhuatán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "611",
                DepartamentoId = 6,
                Nombre = "Guazacapán",
                Descripcion = "Guazacapán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "612",
                DepartamentoId = 6,
                Nombre = "Santa Cruz Naranjo",
                Descripcion = "Santa Cruz Naranjo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "613",
                DepartamentoId = 6,
                Nombre = "Pueblo Nuevo Vi±as",
                Descripcion = "Pueblo Nuevo Vi±as",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "614",
                DepartamentoId = 6,
                Nombre = "Nueva Santa Rosa",
                Descripcion = "Nueva Santa Rosa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "701",
                DepartamentoId = 7,
                Nombre = "Sololá",
                Descripcion = "Sololá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "702",
                DepartamentoId = 7,
                Nombre = "San José Chacayá",
                Descripcion = "San José Chacayá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "703",
                DepartamentoId = 7,
                Nombre = "Santa María Visitación",
                Descripcion = "Santa María Visitación",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "704",
                DepartamentoId = 7,
                Nombre = "Santa Lucía Utatlán",
                Descripcion = "Santa Lucía Utatlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "705",
                DepartamentoId = 7,
                Nombre = "Nahualá",
                Descripcion = "Nahualá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "706",
                DepartamentoId = 7,
                Nombre = "Santa Catarina Ixtahuacán",
                Descripcion = "Santa Catarina Ixtahuacán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "707",
                DepartamentoId = 7,
                Nombre = "Santa Clara La Laguna",
                Descripcion = "Santa Clara La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "708",
                DepartamentoId = 7,
                Nombre = "Concepción",
                Descripcion = "Concepción",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "709",
                DepartamentoId = 7,
                Nombre = "San Andrés Semetabaj",
                Descripcion = "San Andrés Semetabaj",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "710",
                DepartamentoId = 7,
                Nombre = "Panajachel",
                Descripcion = "Panajachel",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "711",
                DepartamentoId = 7,
                Nombre = "Santa Catarina Palopó",
                Descripcion = "Santa Catarina Palopó",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "712",
                DepartamentoId = 7,
                Nombre = "San Antonio Palopó",
                Descripcion = "San Antonio Palopó",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "713",
                DepartamentoId = 7,
                Nombre = "San Lucas Tolimán",
                Descripcion = "San Lucas Tolimán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "714",
                DepartamentoId = 7,
                Nombre = "Santa Cruz La Laguna",
                Descripcion = "Santa Cruz La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "715",
                DepartamentoId = 7,
                Nombre = "San Pablo La Laguna",
                Descripcion = "San Pablo La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "716",
                DepartamentoId = 7,
                Nombre = "San Marcos La Laguna",
                Descripcion = "San Marcos La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "717",
                DepartamentoId = 7,
                Nombre = "San Juan La Laguna",
                Descripcion = "San Juan La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "718",
                DepartamentoId = 7,
                Nombre = "San Pedro La Laguna",
                Descripcion = "San Pedro La Laguna",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "719",
                DepartamentoId = 7,
                Nombre = "Santiago Atitlán",
                Descripcion = "Santiago Atitlán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "801",
                DepartamentoId = 8,
                Nombre = "Totonicapán",
                Descripcion = "Totonicapán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "802",
                DepartamentoId = 8,
                Nombre = "San Cristóbal Totonicapán",
                Descripcion = "San Cristóbal Totonicapán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "803",
                DepartamentoId = 8,
                Nombre = "San Francisco El Alto",
                Descripcion = "San Francisco El Alto",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "804",
                DepartamentoId = 8,
                Nombre = "San Andrés Xecul",
                Descripcion = "San Andrés Xecul",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "805",
                DepartamentoId = 8,
                Nombre = "Momostenango",
                Descripcion = "Momostenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "806",
                DepartamentoId = 8,
                Nombre = "Santa María Chiquimula",
                Descripcion = "Santa María Chiquimula",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "807",
                DepartamentoId = 8,
                Nombre = "Santa Lucía La Reforma",
                Descripcion = "Santa Lucía La Reforma",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "808",
                DepartamentoId = 8,
                Nombre = "San Bartolo Aguas Calientes",
                Descripcion = "San Bartolo Aguas Calientes",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "901",
                DepartamentoId = 9,
                Nombre = "Quetzaltenango",
                Descripcion = "Quetzaltenango",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "902",
                DepartamentoId = 9,
                Nombre = "Salcajá",
                Descripcion = "Salcajá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "903",
                DepartamentoId = 9,
                Nombre = "San Juan Olintepeque",
                Descripcion = "San Juan Olintepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "904",
                DepartamentoId = 9,
                Nombre = "San Carlos Sija",
                Descripcion = "San Carlos Sija",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "905",
                DepartamentoId = 9,
                Nombre = "Sibilia",
                Descripcion = "Sibilia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "906",
                DepartamentoId = 9,
                Nombre = "Cabricán",
                Descripcion = "Cabricán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "907",
                DepartamentoId = 9,
                Nombre = "Cajolá",
                Descripcion = "Cajolá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "908",
                DepartamentoId = 9,
                Nombre = "San Miguel Siguilá",
                Descripcion = "San Miguel Siguilá",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "909",
                DepartamentoId = 9,
                Nombre = "San Juan Ostuncalco",
                Descripcion = "San Juan Ostuncalco",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "910",
                DepartamentoId = 9,
                Nombre = "San Mateo",
                Descripcion = "San Mateo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "911",
                DepartamentoId = 9,
                Nombre = "Concepción Chiquirichapa",
                Descripcion = "Concepción Chiquirichapa",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "912",
                DepartamentoId = 9,
                Nombre = "San Martín Sacatepéquez",
                Descripcion = "San Martín Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "913",
                DepartamentoId = 9,
                Nombre = "Almolonga",
                Descripcion = "Almolonga",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "914",
                DepartamentoId = 9,
                Nombre = "Cantel",
                Descripcion = "Cantel",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "915",
                DepartamentoId = 9,
                Nombre = "Huitán",
                Descripcion = "Huitán",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "916",
                DepartamentoId = 9,
                Nombre = "Zunil",
                Descripcion = "Zunil",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "917",
                DepartamentoId = 9,
                Nombre = "Colomba Costa Cuca",
                Descripcion = "Colomba Costa Cuca",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "918",
                DepartamentoId = 9,
                Nombre = "San Francisco La Unión",
                Descripcion = "San Francisco La Unión",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "919",
                DepartamentoId = 9,
                Nombre = "El Palmar",
                Descripcion = "El Palmar",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "920",
                DepartamentoId = 9,
                Nombre = "Coatepeque",
                Descripcion = "Coatepeque",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "921",
                DepartamentoId = 9,
                Nombre = "Génova",
                Descripcion = "Génova",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "922",
                DepartamentoId = 9,
                Nombre = "Flores Costa Cuca",
                Descripcion = "Flores Costa Cuca",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "923",
                DepartamentoId = 9,
                Nombre = "La Esperanza",
                Descripcion = "La Esperanza",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = "924",
                DepartamentoId = 9,
                Nombre = "Palestina de Los Altos",
                Descripcion = "Palestina de Los Altos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<Municipio>().HasData(municipalities);
    }
}