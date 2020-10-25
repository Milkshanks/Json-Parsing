Hello there. I took the liberty to add this README file so I could quickly write about a few of my considerations and my thought process behind what was done. I hope the cool people reviewing this won't mind.

So, I feel the JSON Parsing part was pretty straightforward. The only catch was that it needed a data model that would accommodate the need for a variable number of data fields from the "Team Members" as well as for the columns.

Now, when preparing the visualization for the parsed data, I took the approach of setting it up by columns and not by rows. It may look counterintuitive at first, but it was done to enable the correct table alignment through the means of Layout Groups.
I'm aware that the instructions said that I shouldn't waste time making the UI look "pretty", but I felt that it should be at least functional enough and resizable to contain variable-sized data.

Lastly, for the table "cells", I decided to instantiate one text component per field. I did this to approximate the implementation to the one used in a game, where we'd have more data in each field than just text. e.g. player inventory or daily rewards pop-up.
Having said that, following the strict use-case presented in the instructions, the best approach would be using a single text component for each column, adding a linebreak at the end of each displayed field. This would eliminate the need for instantiating one game object per field, as it would also allow us to remove the extra Layout Group present in the columns.

All in all, thanks for your time reading this, and I hope to hear from you soon.

Best Regards.
