1.��ν�����Ż��������ǽ����ڲ��ԵĻ���֮�ϣ�ACT Test�ǱȽ�ˬ�Ĳ��Թ��ߣ���Load Runner���㣬��Web Stressֱ�ۣ�֧�ֽű���̺�¼�Ƶ�½��ע��ȫ���̡� 
  �����Ż���Ҫ���жԱȲ��ԣ��������е��������ݡ� 
  ���ԣ�������Ϊ������ѹ�����ԣ��Ż��ǿ���������û������֧�֣��ǲ��Ͻ��ġ�

2.WCF֤����֤:
����ˣ�
	makecert -n "CN=azure.xineapp.com" -pe -sr localmachine -ss My -a sha1 -r -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12
	C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys
	C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys
	http://msdn.microsoft.com/zh-cn/library/bfsktky3.aspx
	http://support.microsoft.com/kb/901183/zh-cn
�ͻ��ˣ�
	certmgr -add -r localmachine -s My -c -n azure.xineapp.com -s TrustedPeople
	CertMgr.msc

3.
  a. C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe D:\Projects\GitLib\Hub\System.Agent.WinService\bin\Debug\System.Agent.WinService.exe
  b. C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /u 'path'

4. 
  a. Https�������ӻ�ȡ���⣻
  b. https://github.com/MSOpenTech/redis;