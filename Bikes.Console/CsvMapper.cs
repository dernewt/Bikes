using Bikes.Core;
using Sylvan.Data.Csv;
using UnitsNet;

namespace Bikes.Console;

public static class CsvMapper
{
    public static IEnumerable<BikeRoute> GetRoutes(this CsvDataReader csv, Dictionary<uint, BikeStation> stationMap)
    {
        /*
         * 0--------,1_____,2___________________,3_____________________,4________________,5__________________,6___________________,7_____________
         * Departure,Return,Departure station id,Departure station name,Return station id,Return station name,Covered distance (m),Duration (sec.)
         * 2021-05-31T23:57:25,2021-06-01T00:05:46,094,Laajalahden aukio,100,Teljäntie,2043,500
         * */
        while (csv.Read())
        {
            var foundDeparture = stationMap.GetValueOrDefault(Convert.ToUInt32(csv.GetInt32(2)))
                ?? BikeStation.Unknown;
            var foundReturn = stationMap.GetValueOrDefault(Convert.ToUInt32(csv.GetInt32(4)))
                ?? BikeStation.Unknown;
            var row = new BikeRoute(
                Departure: csv.GetDateTime(0),
                Return: csv.GetDateTime(1),
                From: foundDeparture,
                To: foundReturn,
                Distance: Length.FromMeters(csv.GetDouble(6)),
                Duration: TimeSpan.FromSeconds(csv.GetInt64(7)));
            yield return row;
        }
    }

    public static IEnumerable<BikeStation> GetStations(this CsvDataReader csv)
    {
        /*
         * seq,id,Name,SwdN,Name,Addres,SwdAdr,City----,SwdC,Operator--,Capacities,ETRS-GK25 (Helsinki) coordinates
         * 0__,1_,2___,3___,4___,5_____,6_____,7_______,8___,9_________,10________,11,12
         * FID,ID,Nimi,Namn,Name,Osoite,Adress,Kaupunki,Stad,Operaattor,Kapasiteet,x,y
         * 1,501,Hanasaari,Hanaholmen,Hanasaari,Hanasaarenranta 1,Hanaholmsstranden 1,Espoo,Esbo,CityBike Finland,10,24.840319,60.16582
         * */
        while (csv.Read())
        {
            var row = new BikeStation(
                Id: Convert.ToUInt32(csv.GetInt32(1)),
                Name: csv.GetString(2),
                Address: csv.GetString(5),
                City: csv.GetString(7),
                Operator: csv.GetString(9),
                Capacity: Convert.ToUInt32(csv.GetInt32(10)),
                X: csv.GetString(11),
                Y: csv.GetString(12)
                );
            yield return row;
        }
    }
}
