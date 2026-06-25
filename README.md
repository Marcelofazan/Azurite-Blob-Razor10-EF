## 🌐 Azurite-Blob-Razor-Net10-EF
Exemplo de armazenamento Blob Storage com Emulador Azurite em C# ASP.NET com banco de dados SQL-Server.

#### 🎨 Aqui está uma demonstração do projeto
<img width="800" height="350" alt="BlobStorage" src="https://github.com/user-attachments/assets/e0d01e8e-ff82-40b0-90f4-f000b494a7d6" />

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **Dicionário de Dados** | Armazenamento de coleções de pares (chave-valor), permitindo busca e recuperação de dados |
| **Blob Storage** | Armazenamento de objetos em nuvem da Microsoft, projetado para guardar imagens, vídeos, documentos |

#### 💬 Requisitos do Projeto
- Necessário Emulador Azurite instalado
- Realizar Migrations EntityFramework .NET


#### 🔄 Executar a aplicação

- No Gerenciador de pacotes Nuget do Visual Studio executar  

```bash 
dotnet ef migrations add BancoInicial --project exemploBlobAzure/exemploBlobAzure.csproj --startup-project exemploBlobAzure/exemploBlobAzure.csproj
Install-Package Microsoft.EntityFrameworkCore.Design
dotnet ef database update --project exemploBlobAzure/exemploBlobAzure.csproj --startup-project exemploBlobAzure/exemploBlobAzure.csproj
```


#### ⚙️ Emulador Azurite 
Para iniciar o emulador abra o Powershell ou Prompt de Comando como Administrador e Digite : **azurite**
- Clique com Botão inverso Atualizar em (Emulador Portas Padrão)
- Crie em Conteineres de Blob -> Botão inverso -> Criar container de Blob , escreva : **blobimages**

As imagens ficarão disponiveis no Storage , Conteineres de Blob , clique no menu na ultima opção em Mais... para atualizar as imagens


