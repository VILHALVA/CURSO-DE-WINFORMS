# DATAGRID
Em aplicações Windows Forms, o controle `DataGridView` é utilizado para exibir e manipular dados tabulares de forma flexível e interativa. Ele permite que você apresente dados de fontes diversas, como listas, arrays, coleções, e até mesmo bancos de dados conectados, oferecendo recursos avançados para ordenação, edição, formatação e seleção de dados. Vamos explorar como configurar e utilizar o `DataGridView` em um projeto Windows Forms.

## Criando e Configurando um `DataGridView`
Para começar, vamos criar um projeto simples e adicionar um `DataGridView` que exibirá dados de uma lista de objetos `Pessoa`. Abaixo estão os passos para configurar e utilizar o `DataGridView`:

1. **Criar o Projeto**

   - Abra o Visual Studio.
   - Crie um novo projeto Windows Forms (por exemplo, `DataGridViewExample`).

2. **Adicionar um `DataGridView` ao Formulário**

   - Arraste e solte um controle `DataGridView` do `Toolbox` para o formulário (`Form1`).

3. **Definir a Classe de Dados**

   - Crie uma classe `Pessoa` com propriedades simples para representar os dados que serão exibidos no `DataGridView`:

     ```csharp
     public class Pessoa
     {
         public string Nome { get; set; }
         public int Idade { get; set; }
     }
     ```

4. **Configurar o `DataGridView` no Formulário**

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

5. **Executar o Projeto**

   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar a aplicação.

## Principais Funcionalidades do `DataGridView`
- **DataSource**: Permite vincular o `DataGridView` a uma fonte de dados, como uma lista, um `BindingSource` ou um `DataSet`.

- **AutoGenerateColumns**: Quando definido como `true`, o `DataGridView` cria automaticamente colunas para todas as propriedades públicas do tipo de objeto na fonte de dados.

- **Column Collection**: É possível personalizar as colunas manualmente adicionando-as à coleção `Columns` do `DataGridView`, definindo o tipo de dado, formato, largura, e outros atributos.

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

## Considerações Finais
O `DataGridView` é um controle poderoso em Windows Forms para exibir e manipular dados tabulares de forma eficiente. Ele oferece uma variedade de recursos para personalização e interação com os dados, facilitando o desenvolvimento de interfaces ricas e funcionais para aplicações desktop. Experimente explorar mais recursos, como eventos de manipulação de dados e formatação avançada, para adaptar o `DataGridView` às necessidades específicas do seu projeto.