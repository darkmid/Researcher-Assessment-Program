   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      > :RAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RAP.ResearchRAP.Research 5         RAP.ResearcherListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      ,localclr-namespace:RAP.Research     5        � 	Resources  5         EmploymentLevel S� 
ObjectType   System.Enum S� 
MethodName S� MethodParameters M� TypeName��%�   &	        S� 5   
   "  65   $ 	GetValues��5       5      M� 5      $ local:EmploymentLevel��6   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��37* �6   �� 5      $	��38* �6    � RowDefinitions 5   
   �� 5      .+�5   
   �� $��Researcher list:��6   $��20(�6+   $
��Bold"�69   $��2��6K   $	��Top=�6_   $��44��6w   �� 5   
   $��Search:��6   $��
10,59,10,0q�6"   $��16(�66   $��Right=�6D   $	��Top=�6g   $��31��6   �� 5!   
   -   5         ��Name$ ResearcherSearchBox��5!      $��0,59,0,0q�6/    �� TextWrapping$
 Wrap=�6A   $��16(�6U   $��1��6c   $	��Top=�6s   $��23��6�   	 �� 
IsReadOnly	 .  6�   �� 5#   
   -   5        
 ��Name$
 ResearcherLevelBox��5#      $��1��6/   $��	0,102,0,0q�6?   $	��Top=�6R   $��24��6j   ��5$   J   ��  �� Source# [  �� 5'   
   -   5         ��Name$ ResearcherList��5'      $��0,139,0,33.286q�6*   $��2��6B   $��18(�6V   ��5(      �� 5)      .R�5*      �� ��5+      `� 5,       �� StringFormat$ {0}, {1} ({2})��6+   .1�5-   "   ��  �� Path$ 
FamilyName�6*   �� 5.   "   $ 	GivenName�6*   �� 5/   "   $ Title�6*   50      52      53      55      �� 57   
   $��Level:��6   $��
10,95,10,0q�6!   $��16(�65   $��Right=�6C   $	��Top=�6f   $��31��6~   �� 5:   
   -   5        $��Report��5:      $��0,0,0,0.286q�6"   $	��152��67   $��33��6C   $��1��6O   $��Bottom=�6_   $��Right=�6z    J� RenderTransformOrigin$ 	0.5,0.513&�6�   5<      5=      