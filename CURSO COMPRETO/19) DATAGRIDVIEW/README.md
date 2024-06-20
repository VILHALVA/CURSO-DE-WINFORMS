# DATAGRIDVIEW
O `DataGridView` é um dos controles mais versáteis e poderosos em aplicações Windows Forms para exibir e manipular dados tabulares. Ele permite a apresentação de dados em forma de grade (ou tabela), onde cada célula pode conter texto, imagens ou outros tipos de conteúdo, além de suportar operações como ordenação, edição, exclusão e seleção de dados. Vamos explorar como configurar e utilizar o `DataGridView` de forma mais detalhada.

## Configuração Básica do `DataGridView`
Para começar, vamos criar um exemplo simples onde um `DataGridView` exibirá dados de uma lista de objetos `Pessoa`. Abaixo estão os passos para configurar e utilizar o `DataGridView`:

1. **Definir a Classe de Dados**

   - Crie uma classe `Pessoa` com propriedades simples para representar os dados que serão exibidos no `DataGridView`:

     ```csharp
     public class Pessoa
     {
         public string Nome { get; set; }
         public int Idade { get; set; }
     }
     ```

2. **Configurar o `DataGridView` no Formulário**

   - No método construtor do formulário (`Form1`), configure o `DataGridView` para exibir dados da lista de pessoas:

     ```csharp
     public partial class Form1 : Form
     {
         private DataGridView dataGridView1;
         private List<Pessoa> pessoas;

         public Form1()
         {
             InitializeComponent();

             // Inicializa a lista de pessoas com alguns dados de exemplo
             pessoas = new List<Pessoa>
             {
                 new Pessoa { Nome = "João", Idade = 30 },
                 new Pessoa { Nome = "Maria", Idade = 25 },
                 new Pessoa { Nome = "Pedro", Idade = 40 }
             };

             // Configurações básicas do DataGridView
             dataGridView1 = new DataGridView();
             dataGridView1.Dock = DockStyle.Fill;
             dataGridView1.AutoGenerateColumns = true;
             dataGridView1.DataSource = pessoas;

             // Adiciona o DataGridView ao formulário
             Controls.Add(dataGridView1);
         }
     }
     ```

3. **Executar o Projeto**

   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar a aplicação.

## Funcionalidades Principais do `DataGridView`
- **DataSource**: Permite vincular o `DataGridView` a uma fonte de dados, como uma lista, um `BindingSource` ou um `DataSet`.

- **AutoGenerateColumns**: Quando definido como `true`, o `DataGridView` cria automaticamente colunas para todas as propriedades públicas do tipo de objeto na fonte de dados.

- **Column Collection**: Permite personalizar as colunas manualmente adicionando-as à coleção `Columns` do `DataGridView`, definindo o tipo de dado, formato, largura, e outros atributos.

- **Edição e Seleção de Dados**: O `DataGridView` suporta edição direta de células e linhas, além de seleção de múltiplas células ou linhas.

## Exemplo de Personalização das Colunas
Para adicionar manualmente colunas ao `DataGridView` e personalizá-las, você pode fazer algo assim:

```csharp
// Exemplo de adição manual de colunas
DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
colunaNome.HeaderText = "Nome";
colunaNome.DataPropertyName = "Nome";

DataGridViewTextBoxColumn colunaIdade = new DataGridViewTextBoxColumn();
colunaIdade.HeaderText = "Idade";
colunaIdade.DataPropertyName = "Idade";

// Adiciona as colunas ao DataGridView
dataGridView1.Columns.Add(colunaNome);
dataGridView1.Columns.Add(colunaIdade);
```

## Manipulação de Eventos
O `DataGridView` também oferece uma variedade de eventos que permitem responder a ações do usuário ou alterações nos dados exibidos. Alguns eventos comuns incluem:

- **CellClick**: Disparado quando o usuário clica em uma célula.
- **CellDoubleClick**: Disparado quando o usuário clica duas vezes em uma célula.
- **CellValueChanged**: Disparado quando o valor de uma célula é alterado.

Você pode manipular esses eventos para implementar lógica personalizada, como validação de dados, atualizações de UI ou execução de operações específicas com base nas interações do usuário.

## Considerações Finais
O `DataGridView` é uma ferramenta poderosa em Windows Forms para exibir e gerenciar dados tabulares de maneira flexível e eficiente. Seu uso adequado pode melhorar significativamente a experiência do usuário ao oferecer uma interface interativa para visualização e manipulação de dados. Ao explorar mais recursos e opções de personalização do `DataGridView`, você poderá adaptá-lo às necessidades específicas de seus projetos.