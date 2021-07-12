# SCPAnnouncement
A small and simple EXILED plugin to announce what SCPs are ingame!

## Requirements
Requires EXILED. Just drop this off in the /EXILED/Plugins/ folder and it will work when you restart your server.

## Configs
| Config | Description | Default Value |
|---|---|---|
| NoSCPs | (string) Sets what Cassie will say when there are no SCPs ingame. | 0 SCPSUBJECTS HAVE BREACHED |
| SCPAnnouncementCassie |  (string) Sets the Cassie announcement [you can use %scpcount and %scpsubjects] | ATTENTION ALL PERSONNEL DETECTED %scpcount SCPSUBJECTS %scpsubjects |
| SCPAnnouncementCassieSingular | (string) Sets the Cassie announcement when there is only 1 SCP.  | ATTENTION ALL PERSONNEL DETECTED %scpcount SCPSUBJECT %scpsubjects |
| CassieDelay | (int) Sets the delay before Cassie says the message. | 3
| Pronounciations | (dictionary) Sets how Cassie pronounces each SCP | (see below)

### Pronounciations
    Scp049: SCP 0 4 9
    Scp079: SCP 0 7 9
    Scp096: SCP 0 9 6
    Scp106: SCP 1 0 6
    Scp173: SCP 1 7 3
    Scp93953: SCP 9 3 9 5 3
    Scp93989: SCP 9 3 9 8 9
    
    
