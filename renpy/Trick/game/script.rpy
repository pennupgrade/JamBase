default persistent.endings = None

# Variables
init python:

    # Characters
    s = Character("Snake",  color="#c8ffc8")
    b = Character("Bird", color="#c8f5ff")
    m = Character('Me', color="#c8c8ff")
    q = Character('???', color="#babac2")

    if persistent.endings is None:
        persistent.endings = set()

init 1 python:
    persistent.endings.add("bad_ending")


label start:

    centered "UPGRADE Game Jam presents..."

    scene bg cage dark

    show guard angry with hpunch

    q "Hey- Wake up!"
    q "We're here."

    m "S-squeak?!"
    "For some reason, everything is dark. Where am I?"

    q "Oh yeah, let me me lift that for you."
    scene bg cage light with easeinbottom
    show guard angry with easeinbottom
    q "Better?"
    q "They told me mice like you are more fragile than a pile of wooden sticks- Commander Snake would kill me if you shriveled up in the dark or something."

    "A snake? I need to find out how I got here."
    "Last I remember, I was going diving into a dumpster to rest for the night after completing my daily goal of looting from the birds' grain stash."
    "This doesn't make sense though: I was just in bird territory, how did this snake get here?"

    q "Haah, you should know how much effort Snake took to find you though."
    q "It's tough to snoop around under the gazes of these birds."
    
    "Great, they definitely picked up my sleeping body and dragged me here."
    "I'm usually a lighter sleeper but maybe hoarding all those grains got me the best night of sleep."
    "But now... I know this isn't just a fever dream: they really did just toss me in this rusty cage."

    hide guard with moveoutleft
    show guard happy with moveinleft

    q "Oh here: brought you some cheese."
    q "You should be so grateful that Commander Snake granted you what your kind enjoys for a last meal."
    q "You got to fatten up anyway before we- oh!"

    show guard happy with moveinleft

    return
