   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5      "    CardGameClient.inGameTopInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +dcclr-namespace:CardGameClient     5      $	��110��5   7   $	��750��6D   ��5	      �� 5
   
     �� ImageSource$/  )/CardGameClient;component/Images/menu.png��6   .��5      � .+�5   
      CardGameClient.Digit  -   5          Name$ 
user1Level��5      $��81,43,639,43q�6'     5   
   -   5        $ 
user2Level��5      $��639,43,81,43q�6'      CardGameClient.StyledBtn  5   
   -   5          Name$ turnBtn��5         Text$  ��6(      TextFontSize$ 15Q�60   $��Center=�6B   $��Bottom=�6_   $	��111��6z   $	��110��6�   ��5      �� 5      $2  ,/CardGameClient;component/Images/btnTurn.png��6      BackgroundNormal 5      �� 5      $2  ,/CardGameClient;component/Images/btnTurn.png��6      BackgroundHover 5      �� 5      $2  ,/CardGameClient;component/Images/btnTurn.png��6   5      �� 5   
   -   5        $��firstUserNick��5      $��user1��6%   $
��Auto��65   $
��Left=�6C   $	��Top=�6^   $��Center=�6v   $1��+/CardGameClient;component/Fonts/#Myriad Pro)�6�   
�������$��13(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��
134,40,0,0q�6  $��82��6(   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 0Q�6#   
   RenderingBias$
 Quality=�62      	Direction$	 330Q�6J      ShadowDepth$ 3Q�6Z   z�5      V� 5      .~�5       ��  �� ScaleX$	 1.2Q�6%   �� 5!      �� 5"      T� 5#      5$      5&      �� 5'   
   -   5        $��twoUserNick��5'      $��user2��6#   $1��+/CardGameClient;component/Fonts/#Myriad Pro)�63   $��13(�6l   
�������$
��Auto��6�   $��Right=�6�   $��Center=�6�   $ 0.5,0.5&�6�   $	��Top=�6�   $��82��6  $��
0,40,134,0q�6   5(        5)      $	 0Q�6#   $	 330Q�62   $
 Quality=�6B   $ 3Q�6Z   z�5+      V� 5,      .~�5-      �� $	 1.2Q�6%   �� 5.      �� 5/      T� 50      51      53      �� 54   
   -   5        $��	turnLabel��54      $
��Auto��6%   $��Center=�63   $��Center=�6P   $��Verdana)�6k   
�������$��13(�6�   $
��Wrap=�6�   $��75��6�    �� TextAlignment$ Center=�6�   $
��None=�6�   $��0,-6,0,0q�6   55        56      $	 0Q�6#   $
 Quality=�62   $	 330Q�6J   $ 3Q�6Z   58      59      5:      