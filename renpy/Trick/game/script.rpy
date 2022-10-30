# Set Up
default persistent.endings = None
default persistent.day = 0

transform common (x=960):
    yanchor 1.0 subpixel True 
    on show:
        ypos 1.00
        zoom 0.95 alpha 0.00 
        xcenter x yoffset 0 
        easein .25 zoom 0.90 alpha 1.00
    on replace:
        alpha 1.00 
        parallel:
            easein .25 xcenter x zoom 0.8 
        parallel:
            easein .15 yoffset 0 ypos 1.03 

transform centerleft:
    common(640)
transform centerright:
    common(1280)

image black = "#000000"

# GUI
define gui.text_font = "gui/font/OpenSans-Medium.ttf"

# Variables
init python:

    # Characters
    s = Character("Snake",  color="#c8ffc8")
    b = Character("Bird", color="#c8f5ff")
    mc = Character('Me', color="#c8c8ff")
    q = Character('???', color="#babac2")
    q2 = Character('???', color="#88888f")

    if persistent.endings is None:
        persistent.endings = set()

    persistent.day = 0

label start:

    if persistent.day == 0:

        centered "UPGRADE Game Jam presents..."

        jump day0

    if persistent.day == 1:

        jump day1

    return

label day0:

    scene bg cage dark with hpunch
    show guard angry

    q "Hey- Wake up!"
    q "We're here."

    mc "S-squeak?!"
    "It's so dark! Who's waking me up in the middle of the night?!"

    q "Oh yeah, let me me lift that for you."
    scene bg cage light with easeinbottom
    show guard angry at common
    $ q_name = "Guard"
    q "Better?"
    "Owwww, that's bright... what time is it? How long did I sleep..."
    q "They told me mice like you are more fragile than a pile of wooden sticks- Commander snake would kill me if you shriveled up in the dark or something."

    "A snake? I need to find out how I got here."
    "Last I remember, I was going diving into a dumpster to rest for the night after completing my daily goal of looting from the birds' grain stash."
    "This doesn't make sense though: I was just in bird territory, how did this snake get here?"

    q "Haah, you should know how much effort Snake took to find you though."
    q "It's tough to snoop around under the gazes of these birds."
    
    "Great, they definitely picked up my sleeping body and dragged me here."
    "I'm usually a heavy sleeper but maybe this is karma for hoarding all those grains."
    "On the bright side, I know this isn't just a fever dream: they really did just toss me in this rusty cage."

    hide guard with moveoutleft
    show guard happy at centerright

    q "Oh here: brought you some cheese."
    "T-that looks nasty. They did peel this m-moldy cheese off some dirty sidewalk?"

    q "You should be so grateful that Commander Snake granted you what your kind enjoys for a last meal."
    q "You ought to get some meat on those bones before we- oh!"

    show snake happy at centerleft

    s "Tsk."
    q "Commander Snake! I'll leave her to you."
    hide guard with moveoutright
    show snake happy at common

    "So she's the so-called commander calling the shots."
    "I can't tell if she's angry at me, or if she just looks like that normally..."
    s "Hey. Why haven't you touched the cheese yet?"

    "Oh, I completely forgot about that... and I'm glad I did- blegh."
    s "Forget it, it won't matter if it's in you or not anyway."
    s "So let's get straight to the point: how did you do it?"

    menu:

        "Did what?":
            
            s "Haha very funny. You better not be trying to feign ignorance."

        "I'll tell you if you tell me why I'm in this cage.":

            s "I'm the one asking the questions here."

    "What is she on about?"

    mc "I don't know what you're talking about."
    
    s "Lies. My guard clearly found you scurrying off from the fresh crime scene." 
    s "We even located fresh footsteps of yours near his location of death."
    s "You think you can get by saying you know nothing straight to my face and saying you know nothing about {color=#4eafc7}{b}my father's death{/b}{/color}?" 

    mc "Your father's death? I don't even know him!"
    "So her dad died? That explains her temper..."
    "Well... I guess I did find out that she's just angry from all the daggers in her gaze."

    s "I strongly advise you not to feed me that lie one more time."
    s "You won't like the consequences."

    mc "Look- I have no idea what he even looks like, what do you expect me to say?"
    "Like hell would she believe me if I said {i}\"I didn't kill your father!\"{/i}"
    "She looks like she won't budge at all."
    
    s "So you accept your fate."
    s "My patience have run thin."
    s "I will ask one last time: {b}how did you do it{/b}?"

    menu:

        "I told you that I did not!":
            
            s "Fine. If that's the case, you're no longer valuable."
            s "Say farewell as I make you my dinner."
            
            "Her what now?"
            "Scared, I backed to the edge of the cage, but I couldn't avoid her snakey bite."

            mc "..."
            "Guess this really is farewell."
            "Hope her stomach acids end my pain quickly-"

    hide snake with moveoutbottom
    scene bg cage dark
    $ persistent.day = 1
    return

label day1:

    scene bg cage light with vpunch
    show snake happy with moveinleft

    scene bg cage dark with hpunch
    show guard angry

    q "Hey- Wake up!"
    q "We're here."

    mc "S-squeak?!"
    "Huh? Is the afterlife meant to look this dark?"

    q "Oh yeah, let me me lift that for you."
    scene bg cage light with easeinbottom
    show guard angry at common
    q "Better?"
    "{i}(Haven't I heard this before...?){/i}"
    q "They told me mice like you are more fragile than a pile of wooden sticks- Commander Snake would kill me if you shriveled up in the dark or something."

    "Commander Snake? That name makes me shiver..."
    "I never want to be in that moist tunnel of hers again."        

    q "Haah, you should know how much effort Snake took to find you though."

    "{i}(I've definitely heard these exact words just yesterday.){/i}"
    "His next line starts with \"It's tought to snoop around\"..."

    q "It's tough to snoop around under the gazes of these birds."
    
    "Great, guess I'm taking another fieldtrip straight to my death."
    "Let me check one thing first."
    mc "Oh by the way: you don't have to bring me that moldy cheese."
    mc "I don't need any extra meat on my bones."

    q "Huh? How did you know I was going to get the cheese?"
    mc "No reason. Can you let me out of this cage?"

    q "Of course I can't! Commander Snake will kill me."
    "Worth a try."

    q "You can only ask her and hope."
    q "I can't wait to see how that would turn out haha."
    "Looks like I had no chance with this puny of a guard."

    show guard happy at centerright
    show snake happy at centerleft

    s "Tsk."
    q "Commander Snake! I'll leave her to you."
    hide guard with moveoutright
    show snake happy at center

    mc "Hold on- Before you say anything."
    "This stupid move will either get me killed or save my life."
    mc "The footprints you saw at the crime scene were from when I visited him weeks ago!"

    s "So you admit those are yours?"
    "Eek- I'll take this story as far as I can anyway."
    
    mc "You see, your father is actually my instructor."
    s "Well, he did take on some disciples, but he never said anything about taking on a mouse?"
    s "You better not be feeding me false information."

    mc "I can explain! Because I was a mouse, he decided to teach me in secret beginning last year."
    mc "He would always praise how hardworking you were as his daughter."
    s "I guess it could happen, seeing as I was out running a business of my own that year."

    mc "Exactly, that's how I learned so much from him."
    mc "He was very quiet about me- Imagine what would happen if word got out that your father, a snake, was teaching a mouse."

    s "Hm..."
    "Looks like I can't completely convince her."
    "But! I will delay a painful death for as long as I can!"

    scene black
    with fade

    mc "I was just as close as you were to him."
    mc "We would often take strolls to the city often."

    s "You mean that forest path near his place? I remember when he would take me and his other students there too."

    mc "That's right!"

    "Bingo! I hit the it on the mark."
    "I'm sure it has been least an hour since I started talking..."
    "I going to keep dragging this snake along with me until nightfall, even if I die."

    scene bg cage light with easeinbottom
    show snake sad at center

    s "I do rather miss him..."
    mc "Condolences... I also remember when he would bake for his students."

    s "Did he?"
    mc "Y-yeah! He started just two weeks ago, he wanted to keep it a secret from you and surprise you."
    mc "But I guess he never got the chance."
    "P-phew, saved myself there. Making up this much backstory takes up so much effort... I'm sweating."

    s "I... guess..."
    s "You were so close to him so you must know who killed him, right?"
    s "Also... can't you also be-?"

    q "SCREEEEEEEEECH!"
    "A loud cry sounded from above. I tried to twist my head to look towards the ceiling, but the black shadow has already filled my vision."

    s "What was-"

    "A whoosh of wind blew past and I could feel the cage rising into the air."
    mc "Woah."
    "Looking up, I finally see the huge (sharp) claws were clamping tight to the top of the cage."
    "It belonged to a huge bird?"

    scene black
    with fade

    q "Beware the turbulence: please don't pass out."
    q "We need you to explain what happened as soon as we land."

    "The cage thumped lightly onto a wooden floor and I woke with a start."

    scene bg courtroom
    with fade

    q "So she's the example?"
    q2 "Is she the petty thief?"
    q "She doesn't look like one though..."

    # TODO: the first time mc is brought to the bird court
    # should end with bird killing mc

    

    
    $ persistent.day = 1
    return

label day1b:
    
    scene bg courtroom
    with fade

    # TODO: the second time mc is brought to the bird court
    # should end with mc successfully sweettalking information out of the bird

    return

label day1c:

    scene bg crimescene
    with fade

    # TODO: the first time mc arrives at the crimescene with the snake
    # they are investingating the scene together
    # should see the bird in the distance

        # choice 1-
        # should end with the mc framing the bird as the killer

        # choice 2-
        # should end with the mc & snake approaching bird & recruiting bird

    show snake happy with moveinleft

    s "Well, here we are. Let's do this quickly, I'd... rather not spend too much time here."

    mc "Yes, yes, he was a great man. I remembered his blueberry muffins so fondly."

    s "...Right."
    s "Well, out with it then. Which way did the culprit go?"

    "Yeesh, right to business."
    mc "Hm... I'm, uh, having trouble remembering."
    mc "You know, because I was knocked out and captured. Thanks for that."
    
    s "{i}Sighs{/i} Out with it."
    "I need something to work with here..."

    mc "Uh, so there was this girl, right? And, uh..."
    
    "In the distance, I see someone else approaching the crime scene."

    menu:

        "Oh, that's her! She was the killer!":
            
            show snake angry at common
            "I knew it. That rotten bird clan!"
            hide snake with moveoutright
            "Snake lunges towards the figure, weapon at the ready."

            show snake angry
            show bird happy

            q "Ah, Commander Snake. Your ugly face is always a sight for sore eyes--"
            "Snake aims a devastating blow at the girl's head"
            s "I'll turn you into poultry!"
            b: "Shown your true colors, huh? Very well!"
            "Bird draws her weapon, and the two engage in combat."
            # jump to something

        "I'm having trouble remembering... maybe that girl over there knows something?":

            s "...Very well then."
            hide snake with moveoutright
            "As Snake walks off, I hear her mutter something about hitting me a little too hard."

            show bird happy
            "As we get closer, I see Snake grimace."

            q "Ah, Commander Snake. Your ugly face is always a sight for sore eyes."
            s "I've no time for your banter for your banter, Bird."

            "I lock eyes with Bird, and her face hardens for just a second."
            "Oh, rats. I think she recognizes me."

            b "Why, I had no idea you were in good company with fugitives. Fitting."
            mc "Yeah, you'd never expect Commander Snake to commit tax fraud, huh?"
            s "Cease. I'm not aware of any crimes this girl has committed outside of our land, but she's helping me avenge my father."
            s "Or rather she's a 'key witness in an ongoing murder case' in your bureaucratic terms."
            b "I never figured you one to even know words that long."
            s "And I never figured you one to obstruct justice. Cut the chatter. Did you see anything here?"
            b "..."
            b "{i}Sighs{/i} Very well, I'll aid you."
            b "I didn't see anything myself, but you'll probably have better luck with me helping you ask around."
            # jump to something

    return

label day2:

    scene bg crimescene
    with fade

    # TODO: the first time mc arrives at the crimescene with the bird
    # they are investingating the scene together
    # should see the snake already at the scene as mc + bird approach

    b "Uh"
    b "What am I supposed to be looking at here."
    mc "Why, this is the site of a heinous crime."
    b "Heinous?"
    mc "Oh yes. An act so wretched it would make your toes curl."
    b "Hey, watch it with the references to my feet. Also why are you talking like that?"
    menu:
        mc "A different writer is writing my dialogue now"
            b "Oh I see so this is just a joke to you"
        mc "This is how I always talk"
            b "Don't play coy with me. Something's up"
    mc "This is getting away from the point"
    mc "Look over there!"
    b "Huh"
    
    show snake sad at centerleft

    mc "Peer upon thy serpentine maiden over yonder"
    b "She seems nice enough. What about her?"
    
    menu:
        # choice 1-
        # should end with the mc framing the snake as the killer of her own father
        mc "She killed her father here"
            b "She WHAT"
            mc "Don't let her distinguished appearnce fool you; she's a bona fide killer."
            b "How could you have known this."
            mc "I tried to stop her, but the venom in her eyes stopped me cold."
            b "Dear god."
            mc "All I could do was watch helplessly in light slowly leave the eyes of her father as she did the deed."
            b "That's...unforgivable."
            mc "More forgivable than...say...petty theft?"
            b "Theft is nothing in the face of this atrocity"
            "Score for me."
            mc "Then I know just want to do"
            jump day3
        # choice 2-
        # should end with the mc & snake approaching snake & recruiting snake

    return

label day2b:

    scene bg birdnest
    with fade

    # TODO: the first time mc arrives at the birdnest with the snake
    # should have the snake break the eggs,
    # should end with snake & bird killing each other

        # choice 1-
        # mc chooses to help snake - gets with snake END

        # choice 2-
        # mc chooses to step back & dies with the battling duo END

    return

label day3:

    scene bg cage light

    # TODO: the last time mc arrives at the cage with the bird
    # should have the bird kill the snake (after seeing the snake break their eggs_)
    # should end with bird killing snake



    return