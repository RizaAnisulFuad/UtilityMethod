using System;
using System.Collections.Generic;
using System.Linq;

class ProgramPengelompokanHuruf {
    static void Main() {

        string[] daftarKata = ["Pendanaan", "Terproteksi", "Untuk", "Dampak", "Berarti"];

        Console.WriteLine("Masukkan huruf :");
        string hurufInput = Console.ReadLine();

        Dictionary<char, int> jumlahHuruf = [];

        foreach (string kata in daftarKata) {
            foreach (char huruf in kata) {
                if (hurufInput.IndexOf(huruf, StringComparison.OrdinalIgnoreCase) >= 0) {
                    if (jumlahHuruf.TryGetValue(huruf, out int nilai)) {
                        jumlahHuruf[huruf] = ++nilai;
                    } else {
                        jumlahHuruf[huruf] = 1;
                    }
                }
            }
        }

        var hurufTerurut = jumlahHuruf.OrderByDescending(kvp => kvp.Value)
                                      .ThenBy(kvp => kvp.Key);

        List<char> hasilAkhir = [];
        int frekuensiSebelumnya = -1;

        foreach (var item in hurufTerurut) {
            if (item.Value != frekuensiSebelumnya) {
                var hurufBesar = hurufTerurut.Where(x => char.IsUpper(x.Key) && x.Value == item.Value)
                                             .OrderBy(x => x.Key)
                                             .Select(x => x.Key);
                hasilAkhir.AddRange(hurufBesar);

                var hurufKecil = hurufTerurut.Where(x => char.IsLower(x.Key) && x.Value == item.Value)
                                             .OrderBy(x => x.Key)
                                             .Select(x => x.Key);
                hasilAkhir.AddRange(hurufKecil);

                frekuensiSebelumnya = item.Value;
            }
        }
        Console.WriteLine(hasilAkhir);
    }
}
