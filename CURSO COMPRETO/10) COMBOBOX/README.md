# COMBOBOX
Para utilizar um controle `ComboBox` em uma aplicação Windows Forms, você pode seguir os passos abaixo. O `ComboBox` é um controle que exibe uma lista suspensa de itens, permitindo que o usuário selecione uma opção dentre as disponíveis.

## Criando e Utilizando um ComboBox em Windows Forms
1. **Criar o Projeto**

   - Abra o Visual Studio.
   - Crie um novo projeto de `Windows Forms App (.NET Framework)` com o nome `ExemploComboBox`.

2. **Adicionar um ComboBox ao Formulário**

   - Na janela `Toolbox`, encontre o controle `ComboBox` e arraste-o para o formulário (`Form1`).

3. **Configurar o ComboBox**

   - Selecione o `ComboBox` no formulário e ajuste suas propriedades no painel `Properties`. Aqui estão algumas propriedades comuns que você pode configurar:

     - **Name**: Define o nome do controle (`comboBoxOpcoes` por exemplo).
     - **Items**: Adicione itens à lista utilizando a propriedade `Items` ou diretamente no designer.
     - **DropDownStyle**: Define o estilo do ComboBox (DropDown, DropDownList, etc.).
     - **SelectedIndex**: Define o índice do item selecionado inicialmente.

   Por exemplo, para um `ComboBox` com o nome `comboBoxOpcoes` e alguns itens:

   ```csharp
   this.comboBoxOpcoes.Name = "comboBoxOpcoes";
   this.comboBoxOpcoes.Items.AddRange(new object[] {
       "Opção 1",
       "Opção 2",
       "Opção 3"
   });
   this.comboBoxOpcoes.DropDownStyle = ComboBoxStyle.DropDownList; // Apenas permite seleção a partir da lista
   this.comboBoxOpcoes.SelectedIndex = 0; // Seleciona o primeiro item inicialmente
   ```

4. **Manipular Eventos do ComboBox**

   - Você pode manipular eventos como `SelectedIndexChanged` para responder às mudanças na seleção do usuário. Dê um duplo clique no ComboBox no designer para criar automaticamente o método de evento no arquivo `Form1.cs`.

5. **Implementar a Lógica no Evento de Mudança de Seleção**

   - No arquivo `Form1.cs`, adicione o código necessário para lidar com o evento `SelectedIndexChanged`. Por exemplo, exiba o item selecionado em um `MessageBox`:

   ```csharp
   private void comboBoxOpcoes_SelectedIndexChanged(object sender, EventArgs e)
   {
       string itemSelecionado = comboBoxOpcoes.SelectedItem.ToString();
       MessageBox.Show($"Item selecionado: {itemSelecionado}");
   }
   ```

## Exemplo Completo
Aqui está o código completo do projeto:

**Form1.cs:**

```csharp
using System;
using System.Windows.Forms;

namespace ExemploComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemSelecionado = comboBoxOpcoes.SelectedItem.ToString();
            MessageBox.Show($"Item selecionado: {itemSelecionado}");
        }
    }
}
```

**Form1.Designer.cs:**

Este arquivo é gerado automaticamente pelo Visual Studio e contém o código relacionado à criação e posicionamento dos controles.

```csharp
namespace ExemploComboBox
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxOpcoes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxOpcoes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            
            // 
            // comboBoxOpcoes
            // 
            this.comboBoxOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOpcoes.FormattingEnabled = true;
            this.comboBoxOpcoes.Items.AddRange(new object[] {
                "Opção 1",
                "Opção 2",
                "Opção 3"
            });
            this.comboBoxOpcoes.Location = new System.Drawing.Point(100, 50);
            this.comboBoxOpcoes.Name = "comboBoxOpcoes";
            this.comboBoxOpcoes.Size = new System.Drawing.Size(150, 21);
            this.comboBoxOpcoes.TabIndex = 0;
            this.comboBoxOpcoes.SelectedIndexChanged += new System.EventHandler(this.comboBoxOpcoes_SelectedIndexChanged);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.comboBoxOpcoes);
            this.Name = "Form1";
            this.Text = "Exemplo de ComboBox";
            this.ResumeLayout(false);
        }
    }
}
```

## Executando o Projeto
1. **Compilar e Executar**
   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar o programa sem depuração.

2. **Interagir com a Aplicação**
   - Abra o ComboBox clicando nele.
   - Selecione uma das opções disponíveis na lista suspensa.
   - Um `MessageBox` deve aparecer, exibindo o item selecionado.

## Resumo
O `ComboBox` é uma maneira eficaz de permitir que os usuários escolham uma opção de uma lista predefinida. Com os passos descritos acima, você aprendeu como configurar um `ComboBox` em um projeto Windows Forms, adicionar itens à lista e responder às seleções do usuário usando eventos. Este controle é amplamente utilizado em interfaces de usuário para oferecer opções de seleção de forma intuitiva e compacta.