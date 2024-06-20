# CHECKEDLISTBOX
Para utilizar um controle `CheckedListBox` em uma aplicação Windows Forms, você pode seguir os passos abaixo. O `CheckedListBox` é útil quando você precisa permitir que o usuário selecione múltiplas opções de uma lista, onde cada item pode ser marcado ou desmarcado.

## Criando e Utilizando um CheckedListBox em Windows Forms
1. **Criar o Projeto**

   - Abra o Visual Studio.
   - Crie um novo projeto de `Windows Forms App (.NET Framework)` com o nome `ExemploCheckedListBox`.

2. **Adicionar um CheckedListBox ao Formulário**

   - Na janela `Toolbox`, encontre o controle `CheckedListBox` e arraste-o para o formulário (`Form1`).

3. **Configurar o CheckedListBox**

   - Selecione o `CheckedListBox` no formulário e ajuste suas propriedades no painel `Properties`. Aqui estão algumas propriedades comuns que você pode configurar:

     - **Name**: Define o nome do controle (`checkedListBoxOpcoes` por exemplo).
     - **Items**: Adicione itens à lista utilizando a propriedade `Items` ou diretamente no designer.
     - **CheckOnClick**: Define se o item deve ser marcado/desmarcado ao clicar nele.

   Por exemplo, para um `CheckedListBox` com o nome `checkedListBoxOpcoes` e alguns itens:

   ```csharp
   this.checkedListBoxOpcoes.Name = "checkedListBoxOpcoes";
   this.checkedListBoxOpcoes.Items.AddRange(new object[] {
       "Opção 1",
       "Opção 2",
       "Opção 3"
   });
   ```

4. **Adicionar Lógica de Evento ao CheckedListBox**

   - Dê um duplo clique no `CheckedListBox` para gerar o método do evento de mudança de estado (`ItemCheck`) no arquivo `Form1.cs`.

5. **Implementar a Lógica no Evento de Mudança de Estado**

   - No arquivo `Form1.cs`, adicione o código necessário para manipular o evento de mudança de estado do `CheckedListBox`. Por exemplo, exibir as opções selecionadas quando um item é marcado ou desmarcado:

   ```csharp
   private void checkedListBoxOpcoes_ItemCheck(object sender, ItemCheckEventArgs e)
   {
       string itemSelecionado = checkedListBoxOpcoes.Items[e.Index].ToString();
       string estado = e.NewValue == CheckState.Checked ? "marcado" : "desmarcado";
       MessageBox.Show($"Item '{itemSelecionado}' foi {estado}");
   }
   ```

## Exemplo Completo
Aqui está o código completo do projeto:

**Form1.cs:**

```csharp
using System;
using System.Windows.Forms;

namespace ExemploCheckedListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBoxOpcoes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemSelecionado = checkedListBoxOpcoes.Items[e.Index].ToString();
            string estado = e.NewValue == CheckState.Checked ? "marcado" : "desmarcado";
            MessageBox.Show($"Item '{itemSelecionado}' foi {estado}");
        }
    }
}
```

**Form1.Designer.cs:**

Este arquivo é gerado automaticamente pelo Visual Studio e contém o código relacionado à criação e posicionamento dos controles, incluindo o `CheckedListBox`.

```csharp
namespace ExemploCheckedListBox
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox checkedListBoxOpcoes;

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
            this.checkedListBoxOpcoes = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            
            // 
            // checkedListBoxOpcoes
            // 
            this.checkedListBoxOpcoes.FormattingEnabled = true;
            this.checkedListBoxOpcoes.Items.AddRange(new object[] {
                "Opção 1",
                "Opção 2",
                "Opção 3"
            });
            this.checkedListBoxOpcoes.Location = new System.Drawing.Point(100, 50);
            this.checkedListBoxOpcoes.Name = "checkedListBoxOpcoes";
            this.checkedListBoxOpcoes.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxOpcoes.TabIndex = 0;
            this.checkedListBoxOpcoes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxOpcoes_ItemCheck);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkedListBoxOpcoes);
            this.Name = "Form1";
            this.Text = "Exemplo de CheckedListBox";
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
   - Marque e desmarque os itens na lista `CheckedListBox`.
   - Uma mensagem deve aparecer indicando qual item foi marcado ou desmarcado.

## Resumo
Neste exemplo, você aprendeu como criar, configurar e utilizar um controle `CheckedListBox` em uma aplicação Windows Forms. O `CheckedListBox` é ideal para permitir que o usuário selecione várias opções de uma lista, fornecendo uma interface intuitiva para gerenciar seleções múltiplas. Ao manipular o evento `ItemCheck`, você pode realizar ações com base nas seleções feitas pelo usuário.