# MAINMENU
O `MainMenu` é um componente comum em interfaces gráficas, permitindo a criação de menus no topo da janela da aplicação. Vamos ver um exemplo de como implementar um menu principal (`MainMenu`) em uma aplicação Windows Forms em C#, seguido de um exemplo equivalente em Tkinter.

## Exemplo de `MainMenu` em Windows Forms (C#)
```csharp
using System;
using System.Windows.Forms;

public class MainMenuForm : Form
{
    public MainMenuForm()
    {
        // Criação do menu principal
        MainMenu mainMenu = new MainMenu();
        
        // Criação dos itens de menu
        MenuItem fileMenu = new MenuItem("File");
        MenuItem editMenu = new MenuItem("Edit");
        
        // Adição de subitens ao menu "File"
        fileMenu.MenuItems.Add(new MenuItem("New", new EventHandler(New_Click)));
        fileMenu.MenuItems.Add(new MenuItem("Open", new EventHandler(Open_Click)));
        fileMenu.MenuItems.Add(new MenuItem("Exit", new EventHandler(Exit_Click)));
        
        // Adição de subitens ao menu "Edit"
        editMenu.MenuItems.Add(new MenuItem("Cut", new EventHandler(Cut_Click)));
        editMenu.MenuItems.Add(new MenuItem("Copy", new EventHandler(Copy_Click)));
        editMenu.MenuItems.Add(new MenuItem("Paste", new EventHandler(Paste_Click)));
        
        // Adição dos itens de menu ao menu principal
        mainMenu.MenuItems.Add(fileMenu);
        mainMenu.MenuItems.Add(editMenu);
        
        // Definição do menu principal do formulário
        this.Menu = mainMenu;
    }

    // Métodos de evento para os itens de menu
    private void New_Click(object sender, EventArgs e)
    {
        MessageBox.Show("New clicked");
    }

    private void Open_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Open clicked");
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Cut_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Cut clicked");
    }

    private void Copy_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Copy clicked");
    }

    private void Paste_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Paste clicked");
    }

    // Método principal
    public static void Main()
    {
        Application.Run(new MainMenuForm());
    }
}
```

## Exemplo Equivalente em Tkinter (Python)
```python
import tkinter as tk
from tkinter import messagebox

def new_file():
    messagebox.showinfo("New", "New clicked")

def open_file():
    messagebox.showinfo("Open", "Open clicked")

def exit_app():
    root.quit()

def cut_text():
    messagebox.showinfo("Cut", "Cut clicked")

def copy_text():
    messagebox.showinfo("Copy", "Copy clicked")

def paste_text():
    messagebox.showinfo("Paste", "Paste clicked")

# Criação da janela principal
root = tk.Tk()
root.title("Main Menu Example")
root.geometry("400x300")

# Criação do menu principal
menubar = tk.Menu(root)

# Criação do menu "File"
filemenu = tk.Menu(menubar, tearoff=0)
filemenu.add_command(label="New", command=new_file)
filemenu.add_command(label="Open", command=open_file)
filemenu.add_separator()
filemenu.add_command(label="Exit", command=exit_app)
menubar.add_cascade(label="File", menu=filemenu)

# Criação do menu "Edit"
editmenu = tk.Menu(menubar, tearoff=0)
editmenu.add_command(label="Cut", command=cut_text)
editmenu.add_command(label="Copy", command=copy_text)
editmenu.add_command(label="Paste", command=paste_text)
menubar.add_cascade(label="Edit", menu=editmenu)

# Adição do menu principal à janela
root.config(menu=menubar)

# Início do loop principal da aplicação
root.mainloop()
```

### Explicação do Código
### C# (Windows Forms)
1. **Criação do MainMenu**: Instancia o objeto `MainMenu`.
2. **Criação e Configuração dos Itens de Menu**: Adiciona itens de menu (`MenuItem`) ao `MainMenu`, incluindo subitens e associando-os a event handlers.
3. **Definição do Menu Principal do Formulário**: Associa o `MainMenu` ao formulário.
4. **Event Handlers**: Define os métodos que serão chamados quando os itens de menu forem clicados.

### Python (Tkinter)
1. **Criação da Janela Principal**: Cria a janela principal da aplicação com `tk.Tk()`.
2. **Criação do Menu Principal**: Instancia o objeto `Menu`.
3. **Criação e Configuração dos Menus e Submenus**: Adiciona menus (`Menu`) ao `menubar` e subitens a esses menus, associando-os a funções de callback.
4. **Configuração do Menu Principal da Janela**: Configura o `menubar` como o menu principal da janela.
5. **Início do Loop Principal**: Chama `root.mainloop()` para iniciar o loop principal.

Ambos os exemplos mostram como criar um menu principal com subitens, mas em diferentes ambientes de desenvolvimento: C# com Windows Forms e Python com Tkinter.