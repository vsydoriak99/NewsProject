   M S B A M L   `   `   `  ����P  LNewsProject.ClientWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NewsProject.ClientWPFNewsProject.ClientWPF  5      *    $NewsProject.ClientWPF.DetailNewsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:NewsProject.ClientWPF     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6!   �� 5      $��* �6   �� 5      $��* �6   �� 5      $	��10* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� -   5        $	��100��5      $
��Left=�6   $��0��68   $
��Back��6F   6U   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6/   .+�5      �� $��Title : ��6   6*   �� 5      ��6   �� *CurrentNews.Title+6=   5      �� 5   
   $ 
Horizontal=�6   $��2��6/   .+�5      �� $��URL : ��6   6(   �� 5      ��6   �� *CurrentNews.Url+6;   5      �� 5   
   $��3��6   ��6!   �� *CurrentNews.DatePublication+�� 5   
   $��4��6   $
��Wrap=�6!   ��65   �� *CurrentNews.Description+�� 5    
   $��5��6   $ 
Horizontal=�6"   .+�5!      �� 
Keywords :6%   �� 5"      ��6   �� *CurrentNews.KeywordStr+6B   5#      �� 5%   
   $��6��6   ��6    �� *LikeCommand+��5&      �� 5'       �� 
TargetType" ��6    �� Triggers 5(      �� 5)       �� Binding 6&   �� *CurrentNews.UserLikesThis+ �� Value True6T   .a�5*      ��  �� Property � �� �� Value$ Unlike��68   5+      �� 5,       6&   �� *CurrentNews.UserLikesThis+	 False6T   .a�5-      ��  � ��$
 Like��68   5.      50      52      53      54      