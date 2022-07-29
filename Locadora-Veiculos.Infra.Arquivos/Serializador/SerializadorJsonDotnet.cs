//using Newtonsoft.Json;
//using System.IO;

//namespace Locadora_Veiculos.Infra.Arquivos.Serializador
//{
//    public class SerializadorJsonDotnet
//    {
//        private const string arquivo = @"C:\temp\dados.json";

//        public Contexto CarregarDadosDoArquivo()
//        {
//            if (File.Exists(arquivo) == false)
//                return new Contexto();

//            string arquivoJson = File.ReadAllText(arquivo);

//            JsonSerializerSettings settings = new JsonSerializerSettings();

//            settings.Formatting = Formatting.Indented;
//            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

//            return JsonConvert.DeserializeObject<Contexto>(arquivoJson, settings);
//        }

//        public void GravarDadosEmArquivo(Contexto dados)
//        {
//            JsonSerializerSettings settings = new JsonSerializerSettings();

//            settings.Formatting = Formatting.Indented;
//            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

//            string arquivoJson = JsonConvert.SerializeObject(dados, settings);

//            File.WriteAllText(arquivo, arquivoJson);
//        }
//    }
//}
