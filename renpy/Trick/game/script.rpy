# Set Up
default persistent.lastending = ""
default persistent.badendreached = False
default persistent.zuruendreached = False
default persistent.fleurendreached = False
default persistent.haremendreached = False
default persistent.pairendreached = False

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
    s = Character("Zuru",  color="#c8ffc8")
    b = Character("Fleur", color="#c8f5ff")
    mc = Character('Me', color="#c8c8ff")
    q = Character('???', color="#babac2")
    q2 = Character('???', color="#88888f")

    persistent.lastending = ""

label start:

    if persistent.lastending == "":

        centered "UPGRADE Game Jam presents..."

        jump day0

    elif persistent.lastending == "0": # finished day 0

        jump day1

    elif persistent.lastending == "1": # finished day 1

        jump day1b

    elif persistent.lastending == "4" or persistent.lastending == "5" or persistent.lastending == "6":

        if persistent.lastending == "4":
            
            centered "That last death was much too brutal. I should've known how to prevent it."
            centered "I'll do it right this time around."

        elif persistent.lastending == "5":

            if persistent.haremendreached or persistent.pairendreached:

                centered "After reaching these endings, I wonder if things would be different if I acted differently."
                
            else:

                centered "I still haven't found out who killed Zuru's father..."

        elif persistent.lastending == "6":

            centered "After reaching such a perfect ending, I wonder if things would be different if I acted differently."

        jump day0a

    return

label day0a:

    scene bg cage dark with hpunch
    show guard angry

    q "Hey- Wake up!"
    q "We're here."

    mc "You b-bastard!"
    "{i}I really want to punch this guy."
    "As I violently shook within the cage, the covering slipped off."

    q "What?"

    mc "Haah... nevermind. Let's just get on with the story."
    mc "I'm trying to reach the other endings right now."

    q "S-so what are you planning on doing?"

    menu:

        "I will lead an enraged Zuru to ruin Fleur's beloved eggs!":

            jump day2b

        "I will use Fleur's goodwill to take {i}care{/i} of Zuru~":

            jump day3

        "I want to find out who killed Zuru's father.":

            jump day3b

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
    q "They told me mice like you are more fragile than a pile of wooden sticks- Commander Zuru would kill me if you shriveled up in the dark or something."

    "I need to find out how I got here."
    "Last I remember, I was going diving into a dumpster to rest for the night after completing my daily goal of looting from the birds' grain stash."
    "This doesn't make sense though: I was just in bird territory, how did this snake get here?"

    q "Haah, you should know how much effort Zuru took to find you though."
    q "It's tough to snoop around under the gazes of these birds."
    
    "Great, they definitely picked up my sleeping body and dragged me here."
    "I'm usually a heavy sleeper but maybe this is karma for hoarding all those grains."
    "On the bright side, I know this isn't just a fever dream: they really did just toss me in this rusty cage."

    hide guard with moveoutleft
    show guard happy at centerright

    q "Oh here: brought you some cheese."
    "T-that looks nasty. Did they peel this m-moldy cheese off some dirty sidewalk?"

    q "You should be so grateful that Commander Zuru granted you what your kind enjoys for a last meal."
    q "You ought to get some meat on those bones before we- oh!"

    show zuru happy at centerleft

    s "Tsk."
    q "Commander Zuru! I'll leave her to you."
    hide guard with moveoutright
    show zuru happy at common

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
    s "My patience has run thin."
    s "I will ask one last time: {b}how did you do it{/b}?"

    menu:

        "I told you that I did not!":
            
            s "Fine. If that's the case, you're no longer valuable."
            s "Say farewell as I make you my dinner."
            
            "Her what now?"
            "Scared, I backed to the edge of the cage, but I can't avoid her snakey bite."

            hide zuru with moveoutbottom
            scene black with fade

            mc "..."
            "Guess this really is farewell."
            "Hope her stomach acids end my pain quickly-"

    centered "BAD END REACHED: Down The Hatch"
    centered "If I knew what was going to happen to me, perhaps I could've prevented it."
    $ persistent.lastending = "0"
    return

label day1:

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
    q "They told me mice like you are more fragile than a pile of wooden sticks- Commander Zuru would kill me if you shriveled up in the dark or something."

    "Commander Zuru? Hearing that name makes me shiver..."
    "I never want to be in that moist tunnel of hers again."        

    q "Haah, you should know how much effort Zuru took to find you though."

    "{i}(I've definitely heard these exact words just yesterday.){/i}"
    "His next line starts with \"It's tought to snoop around\"..."

    q "It's tough to snoop around under the gazes of these birds."
    
    "Great, guess I'm taking another fieldtrip straight to my death."
    "Let me check one thing first."
    mc "Oh by the way: you don't have to bring me that moldy cheese."
    mc "I don't need any extra meat on my bones."

    q "Huh? How did you know I was going to get the cheese?"
    mc "No reason. Can you let me out of this cage?"

    q "Of course I can't! Commander Zuru will kill me."
    "Worth a try."

    q "You can only ask her and hope."
    q "I can't wait to see how that would turn out, haha."
    "Looks like I had no chance with this puny of a guard."

    show guard happy at centerright
    show zuru happy at centerleft

    s "Tsk."
    q "Commander Zuru! I'll leave her to you."
    hide guard with moveoutright
    show zuru happy at center

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
    mc "We would often take strolls to the city."

    s "You mean that forest path near his place? I remember when he would take me and his other students there too."

    mc "That's right!"

    "Bingo! I hit the it on the mark."
    "I'm sure it has been least an hour since I started talking..."
    "I'm going to keep dragging this snake along with me until nightfall, even if I die."

    scene bg cage light with easeinbottom
    show zuru sad at center

    s "I do rather miss him..."
    "Zuru turned her face away from you, trying to hide her very obvious tears"
    mc "My condolences... I also remember when he would bake for his students."

    s "Did he?"
    mc "Y-yeah! He started just two weeks ago. He wanted to keep it a secret from you and surprise you."
    mc "But I guess he never got the chance."
    "P-phew, saved myself there. Making up this much backstory takes up so much effort... I'm sweating."

    s "I... guess..."
    s "You were so close to him, so you must know who killed him, right?"
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
    q2 "Oh my god!! Judge Fleur brought her here~"
    q "I LOVE YOU FLEUUUUUUUR!"
    "Have I been saved?! My heart was thumping with adrenaline but now I'm finally calming down again."

    show fleur happy at common

    b "Quiet in the court! We have an important matter to discuss."
    b "Our esteemed, or shall I say long awaited, guest has finally arrived."
    "Oh- I feel honored! She really went through all the effort of bringing me here from that snake's grasps."
    "She looks so nice <3"

    b "We are all gathered here today to trial her innocence."
    b "As you all have learned, this little mouse is suspect for plundering our depository of our winter grains!"
    "Oh wow. She's actually accusing me of something I did do this time."
    "Haha... H-how do I get out of it this time."

    b "We must make her an example that all fiends who dare trespass our clan's lands are punished accordingly."
    "W-wait they're gonna punish me?"

    mc "U-um can I say that I am grateful for you saving me but I'm not into th-"

    b "Quiet. Motion to speak {b}denied{/b}."
    "Ouch."
    b "As I was saying, all in favor for making her an example here and now, say AYE."

    q "AYE!"
    q2 "AYYYYYYEEEE-"
    
    b "All against, say NAY?"

    q "..."
    "..."
    mc "Nay?"

    b "Looks like we have come to an overwhelming, if not unanimous decision:"
    b "I will now deliver the punishment."
    "I look over at Fleur in fear and suddenly, she looks back and our eyes meet."
    
    mc "Uh oh."
    "I don't like that look."
    "I just saw it yesterday... I'm not ready to go through this again..."

    b "Aaaa-"
    "Yup. Against all expectations, I'm getting picked up again-"

    hide fleur with moveoutbottom
    scene black with fade
    
    "And yuuuuup. I guess I am going down the hatch. Yet again."

    "Guess this really is farewell once again."
    "Hope her stomach acids end my pain quickly-"

    centered "BAD END REACHED: Out of the Frying Pan, Into the Fire"
    $ persistent.lastending = "1"
    return

label day1b:

    scene bg cage dark with hpunch
    show guard angry

    q "Hey- Wake up!"
    q "We're here."

    mc "S-squeak?!"
    "Bruh."

    q "Oh yeah, let me me lift that for you."
    scene bg cage light with fade
    show guard angry at common
    q "Better?"
    "{i}(Not again...){/i}"
    q "They told me mice like you are more fragile than a pile of wooden sti-"

    mc "{i}\"-sticks. Commander Zuru would kill me if you shriveled up in the dark or something.\""
    mc "{i}\"Haah, you should know how much effort Zuru took to find you though.\""

    q "H-how do you-"

    mc "{i}\"It's tough to snoop around under the gazes of these birds.\""

    mc "Oh by the way: you don't have to bring me that moldy cheese."
    mc "Also can you get Zuru to come here? I'm tired of waiting."

    q "What did you just call her?! And you literally just woke up!"

    "I really don't want to deal with this right now."
    mc "I said what I said."
    mc "Get her or I'll yell for her to come."

    q "I guess..."

    hide guard with moveoutright
    show zuru happy at common

    mc "Hey bestie Zuru, before you say anything... Let me tell you everything about your dad."
    s "Tell me WHAT?"
    "This snake lady better hold her tears better this time. I am at the end of my patience too."

    scene black
    with fade

    mc "And you know the strolls he takes?"
    s "Mhm..."

    scene bg cage light with fade
    show zuru sad at common

    mc "Holy crap... I'm losing my voice..."
        "{i}(...and my will to live to be honest.){/I}"
    s "{i}Hic...{/i} W-well... with this much specific information about my father I know you at least aren't completely lying through your teeth."
    mc "I would never. So, uh... Can you let me out."

    "Zuru's eyes grow stern."
    s "I... cannot do that. You are under our custody."

    "Whoops. Overstepped a little."
    "Rats. I've gotten her guard down, but not quite enough. What should I do?"

    menu:

        "{i}(I should use her against Fleur.)":

            "Right, that bird should be coming soon. Just a few more stories about old man stuff."
            mc "Well, I'll tell you a little more about your father then."
            "Another hour of "

            mc "(hoarse) And then his skin shed like crazy and he went 'Woah! I'm peeling like a banana to peel on you!'"
            s "I... did not know my father to have such a sense of humor. A man of many sides, it appears."

            mc "Yeah... for... sure..."
            "God, the bird should be here anytime n-"

            q "SCREEEEEEEEECH!"
            "There she is."

            s "What was-"
            
            mc "Zuru! I'll be back!"

            hide zuru with moveoutleft

            "Looking up, it's still those same huge sharp claws {b}AND BEAK{/b} atop the cage."
            "{i}(I really hope I don't throw up this time.)"

            scene black
            with fade

            mc "Yo Fleur!"
            "The cage shook lightly. Sounds like she heard me."

            mc "HEY FLEUUUUUUR~"
            mc "Before you get so hasty, I need to show you something."

            b "Shut up. You can show it to me at court."
            "Darn. Okay I'll convince her when we get there."

            "The cage thumped again onto the wooden floor."

            scene bg courtroom
            with fade

            q "So she's the example?"
            q2 "Is she the petty thief?"
            q "She doesn't look like one though..."
            q2 "Oh my god!! Judge Fleur brought her here~"
            q "I LOVE YOU FLEUUUUUUUR!"

            show fleur happy at common

            mc "HEY EVERYONE."
            mc "Before you all ruffle your feathers with some minor things you {i}think{/i} I did."
            mc "I've just stumbled upon an even more heinous crime: {b}MURDER{/b}."

            q "GAASPPPP."
            q2 "hUUUH??"

            b "Quiet in the court!"
            
            q "A what? Murder? Noooooo."
            q2 "Not a murder?? Is this on our land too?"

            b "O-okay okay..."
            "If Fleur isn't caving, I'll keep pushing it."
            "I'm sure if I stall long enough, perhaps Zuru might even come get me~"

            mc "I can show you the PROOOOOOF."

            q "PROOOOOOOF?!"
            "This crowd is really excited. They love sure love to heckle."
            q "Motion to hear this heinous crime?!"
            q2 "Seconded!"

            "Hah. Gottem."

            b "Fine. Motion to investigate this new, so-called, crime? All in fa-"
            
            q "AYYYYYEE~"
            a2 "AYE!"
            mc "LET'S GOOOOOOOOO!"

            b "...Looks like that was unanimous. Alright. I will take this tiny mouse... and we will be back."

            jump day2

        "{i}(I can press a little more!)":

            mc "H-hey, you want to know who is your father's real killer, right?"
            "Zuru perks up."
            s "Of course."

            mc "If you take me to the crime scene, I can point out which way they went."
            "Zuru ponders for a moment."
            s "Fine. Come with me."
            s "Sure, come with me."

            jump day1c

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

    show zuru happy at common

    "While walking, Zuru has clearly composed herself and is back in {s}girlboss{/s} commander mode."
    s "Well, here we are. Let's do this quickly, I'd... rather not spend too much time here."

    mc "Yes, yes, he was a great man. I remembered his blueberry muffins so fondly."

    s "...Right."
    "Looks like she still doesn't quite buy that one."

    s "Well, out with it then. Which way did the culprit go?"

    "Yeesh, right to business."
    mc "Hm... I'm, uh, having trouble remembering."
    mc "You know, because I was knocked out and captured. Thanks for that."
    
    s "{i}Sighs{/i} Out with it."
    "I need something to work with here..."
    
    "Out of the corner of your eye, you see something-- someone, flying through the trees."
    "That's right, Fleur!"

    menu:

        "Oh, that's her! She was the killer!":
            
            show zuru angry at common
            "I knew it. That rotten bird clan!"
            hide zuru with moveoutright
            "In a flash, Zuru scales a tree lunges towards the figure, weapon at the ready."

            show zuru angry
            show fleur happy

            q "Ah, Commander Zuru. Your ugly face is always a sight for sore eyes--"
            "Zuru aims a devastating blow at the bird's head."
            q "Shown your true colors, huh?"
            s "Shut up Fleur! I'll turn you into poultry!"
            b "And I'll turn you in to law enforcement! See you in court!"
            "Fleur flies high, out of the reach of the trees, and back towards the clear"
            s "Argh!"
            "Panting, I finally catch up to Zuru."
            mc "Woah, you alright there?"
            s "Cease your pleasantries."
            mc "Y-yeah! That darn bird! So, am I off the hook? Can I go?"
            s "We can talk about that another time. Right now, it is time to avenge my father--"
            s "-- and your instructor."
            mc "Ah."

            jump day2b

        "I'm having trouble remembering... maybe that bird up there might know something?":

            mc "I mean she must have a pretty good view of things."
            s "...Very well then."
            hide zuru with moveoutright
            "As Zuru walks off, I hear her mutter something about the guards roughing me up a little too hard."
            "She takes a big breath"
            s "EXCUSE ME! WE HAVE A FEW QUESTIONS!"

            "The bird is clearly startled, and flies into a tree."
            mc "Ouch. That probably hurt."

            show fleur happy at centerleft
            show zuru happy at centerright
            "As the bird lands, Zuru grimaces-- seems they know each other."

            b "Ah, Commander Zuru. Such an ugly voice could only be yours."
            s "I've no time for your banter, Fleur."

            "I lock eyes with Fleur, and her face hardens for just a second."
            "Oh, rats. I think she recognizes me."

            b "Why, I had no idea you were in good company with fugitives. Fitting."
            mc "Yeah, you'd never expect Commander Zuru to commit tax fraud, huh?"
            s "Cease. I'm not aware of any crimes this girl has committed outside of our land, but she's helping me avenge the murder my father."
            s "Or rather she's a 'key witness in an ongoing murder case' in your bureaucratic terms."
            b "I never figured you one to even know words that long."
            s "And I never figured you one to obstruct justice. Cut the chatter. Did you see anything here?"
            b "..."
            b "{i}Sighs{/i} Very well, I'll aid you."
            b "I didn't see anything myself, but you'll probably have better luck with me helping you ask around."

            jump day3b

    return

label day2:

    scene bg crimescene
    with fade

    # TODO: the first time mc arrives at the crimescene with the bird
    # they are investingating the scene together
    # should see the snake already at the scene as mc + bird approach

    b "Uh,"
    b "what am I supposed to be looking at here."
    mc "Why, this is the site of a heinous crime."
    b "Heinous?"
    mc "Oh yes. An act so wretched it would make your toes curl."
    b "Hey, watch it with the references to my feet. Also why are you talking like that?"
    menu:

        "A different writer is writing my dialogue now":

            b "Oh I see so this is just a joke to you"

        "This is how I always talk":

            b "Don't play coy with me. Something's up"

    mc "This is getting away from the point"
    mc "Look over there!"
    b "Huh"
    
    show zuru sad at centerleft

    mc "Peer upon thy serpentine maiden over yonder"

    b "She seems nice enough. What about her?"
    
    menu:
        # choice 1-
        # should end with the mc framing the snake as the killer of her own father
        "She killed her father here":
        
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
        "Look how she weeps":

            b "She does not weep? I see no tears in her eyes."
            mc "Peer beyond her mask of stone"
            mc "..."
            mc "and into the misty eyes of her soul."
            b "w.."
            b "..wow"
            b "When did you get so poetic?"
            mc "I am merely describing what I see"
            #have the bird blush 
            b "Well...then it is only just that we help her"
            #have snake appear on screen
            b "Madam...are you alright?"
            s "..."
            b "Madam?"
            s "...hm?"
            b "You seem troubled."
            s "Do I?" #she should have a very neutral face
            mc "It's written all over your face"
            b "Y-yeah! It's so obvious."
            b "Anyone with even a modicum of emotional intelligence could tell that from a mile away"
            s "Really?"
            b "I simply peered past your mask of stone"
            b "and..."
            s "..."
            b "...(what was it again)"
            mc "(into the misty eyes of-)"
            b "Into the misty eyes of her soul."
            "I roll my eyes"
            #Snake blushes
            mc "Maiden. What troubles you?"
            s "My father..."
            s "He lays slain upon this very earth."
            b "How wretched...Truly heinous."
            mc "Far more wretched than petty theft."
            b "By far..."
            b "Maiden. We must right this wrong and bring the perpetrator of this act to justice."
            s "I am perfectly capable of avenging my father myself."
            b "..."
            mc "We offer aid not because we believe you unfit. We seek to aid because this is a matter of Justice."
            b "What she said."
            s "Very well. Then I know just the place to check out."
            jump day3b

    return

label day2b:

    scene bg birdnest_with_egg
    with fade

    # TODO: the first time mc arrives at the birdnest with the snake
    # should have the snake break the eggs,
    # should end with snake & bird killing each other

        # choice 1-
        # mc chooses to help snake - gets with snake END

        # choice 2-
        # mc chooses to step back & dies with the battling duo END

    mc "Ok, so, we're at her house. What's the plan here? Wait around the corner and beat her up when she gets home from work?"
    s "An eye for an eye."
    "Zuru turns her gaze to the eggs."
    "Oh. The plan is infanticide."
    "Ok, I'm not about to go from alleged to {i}actual{/i} murderer. I gotta get out--"
    s "Stop glancing around and dragging your feet. Revenge is our singular goal."
    mc "O-oh, I just... uh..."
    mc "Still... miss him, you know?"

    "Zuru's expression softens."
    s "I... apologize for my roughness. I have... also been affected by his passing."
    s "We'll turn these eggs into blueberry muffins, just like he would've wanted, right?"
    mc "Y-yeah, for sure."

    scene bg birdnest
    with fade

    "Zuru snatches the eggs, cracks them open, then carefully dumps their contents into a bottle."
    "She smiles at me, holding out the bottle of child juice."
    s "Would you do the honors of separating the yolks from the whites?"
    mc "Uh, maybe later. For now, let's get out here--"
    b "I should've known."
    
    "Oooof course."

    show bird sad at common

    s "Ha! Now you can experience the loss of a loved one."
    b "I've not the foggiest idea of what I've done to you."
    b "Everyone is reserved the right to due process."
    b "But considering what you've done here, I'm willing to skip the formalities."

    "Fleur draws her weapon."
    s "Finally ready to stop running, huh?"
    "The two begin their duel. It's fierce, but it doesn't look like either one of them is winning."
    menu:

        "I'm out of here!":

            "I take a few cautious steps back."
            mc "I'm gonna leave you two to it..."
            s "What are you doing!? Think of him! Think of vengeance."
            b "Oh? This little one means something you?"
            b "I'll give you an {i}actual{/i} reason to hate me."
            "A sharp pain erupts from my back. Strength leaves my whole body."
            s "You'll pay for that!"
            "Bleeding out, I watch two warriors savagely fight over a misunderstanding that I caused."
            
            scene black
            with fade

            centered "BAD END REACHED: Mass Manslaughter"
            $ persistent.lastending = "4"
            $ persistent.badendreached = True

        "Flying is weak to rock!":

            "Frantically looking around the area, I try to find anything heavy enough to deal some damage."
            "I settle on a rock about the size of my head."
            mc "What am I even doing? I'm no fighter. I was just not five minutes ago complicit in the murder of children. I am not a good person"
            "Zuru, in the midst of battle notices your courage."
            s "{i}Though not related by blood, She is risking her life for my father's sake all the same... she's such a good person...{/i}"
            "She feels a warm energy swell up inside of her, and summons new strength."
            "She manages to overpower Fleur, knocking her to the ground. Coincidentally, right at me feet."
            mc "Jesus, I can not hold this rock any longer...!"
            "I drop the rock. Coincidentally, right onto Fleur's head. With a squawk, she stops moving."
            mc "Oh my god."

            s "I..."
            s "Words cannot describe my gratitude to you."
            s "You have not only found my father's killer, but you have also avenged him with your own two hands."
            mc "No, uh, if the police come, we'll say you did that."
            s "You are too kind. But it was you who dealt the final blow."
            mc "No really, I insist."
            "Zuru laughs."
            s "Beat at ease. I will formally acquit you of your crimes when we get back."
            s "But first..."
            mc "But first?"
            s "Would you be so kind as to... show me my father's baking technique?"
            mc "W-with pleasure! Don't expect too much though."

            "I make my way back to the snake village a free woman."

            scene black
            with fade

            centered "GOOD END REACHED: SSSSSSSlipped Away With Zuru"
            $ persistent.lastending = "5"
            $ persistent.zuruendreached = True

    return

label day3:

    scene bg cage light

    # TODO: the last time mc arrives at the cage with the bird
    # should have the bird kill the snake (after seeing the snake break their eggs_)
    # should end with bird killing snake
    b "Where is this?"
    mc "The lair of the monster."
    b "How can be so sure?"
    mc "I..."
    b "?"
    mc "I shudder to recount what she did to me here."
    b "Oh my. What unspeakable things befell you here?"
    mc "I dare not speak of it."
    b "..."
    #Sad birb face
    mc "What is that look? Upon your face?"
    b "I just want to know what injustice has wrought."
    mc "That's what you say. But I see it in your eyes."
    b "M-m-my eyes?"
    #Blush birb
    mc "Behind your drive for justice, a fiery compassion burns even more brightly."
    b "W-what"
    mc "I see now."
    b "What's going on here."
    mc "You ask not just because you stand for justice..."
    mc "You ask because you care."
    b "I..."
    mc "Your eyes..."
    mc "They..."
    mc "Emanate with warmth"
    b "Wh-where's all of this coming fro-"
    mc "You are...simply too radiant"
    #Birb leaves
    b "Where are you going!"
    "I think she took the bait"
    #Snek appears on screen
    s "You!"
    mc "..."
    s "What happened? Last I saw you were swept up by one of the bird clan. Are you alright?"
    mc "..."
    s "Why aren't you saying anything?"
    mc "..."
    s "No matter. Come quickly, we must continue discussing the whereabouts of my father's killer."
    mc "8 hours, 45 minutes, and 32 second."
    s "I beg your pardon?"
    mc "That's how long I remained concious while being digested by your stomach acids."
    s "What?"
    mc "I wouldn't expect you to remember. But you killed me."
    s "What? I did no such thing."
    mc "But you would have."
    b "Hellooooo?"
    s "Who's that?"
    mc "A friend."
    b "Are you there? Mouse?"
    s "Is she sympathetic to our cause?"
    mc "You would have let me rot in a pool of my own flesh."
    "I hear Fleur's footsteps grow louder as they approach."
    mc "Writhing in pain, dissolving in a puddle of mush just for providing an incorrect answer to an impossible question."
    s "What?"
    mc "Goodbye Zuru."
    s "What are you talking about-"
    "I begin to scream at the top of my lungs."
    mc "FLEUR!!!!! RUN!!!!!!"
    #Snek shock
    s "What are you-"
    mc "THE SERPENTINE MAIDEN! NAY! THE MONSTER! THE DEVIL"
    b "Mouse?!"
    "Fleur's footfalls hasten"
    mc "PLEASE! RUN! I MAY GO THE WAY HER FATHER WENT, BUT YOU CAN STILL SAVE YOURSELF"
    s "My father? What are you-"
    #Shocked birb appear left
    mc "FLEUR! STAY BACK!"
    b "MOUSE! What has the monster done to you?!"
    mc "JUST RUN"
    #Birb murder mode activated
    b "Put."
    b "Her."
    b "Down."
    "Zuru looks at me in shock and despair. I sneak a grin before turning to my faux tears."
    b "YOU WILL DO NO FURTHER HARM ANYMORE INNOCENTS"
    "Zuru meets my gaze. She's crying."
    s "Why you-"
    "There is a flash; the sound of a fleshy sploch. When I open my eyes, Zuru's head lies at my feet."
    b "Mouse."
    mc "Y-you didn't leave me."
    #Happy birb
    b "I am but a humble messenger for the hammer of justice"
    scene black
    with fade

    centered "GOOD END REACHED: Courted Fleur"
    $ persistent.lastending = "5"
    $ persistent.fleurendreached = True

    # b "KISS ME" mAssive  makeout scene xp

    return

label day3b:

    # TODO: both zuru and fleur work together to discover the true culprit of the case
    # you can either push them to get together (pairing end)
    # and/or get them to fall in love with you (harem end)

    scene black
    with fade

    "Clattering and banging sounded from around as Fleur and Zuru headed off in their directions, searching for evidence."

    mc "Have you two found anything of worth?"

    s "Not yet. Nature is too good at hiding things."
    b "Almost like a treasure trove hidden for you to discover~!"

    s "Ugh."
    
    scene bg crimescene with fade

    "It's been awhile since we split up. We planned to reconvene about now-ish?"

    show fleur happy at centerleft
    show zuru happy at centerright

    mc "Updates?"
    b "Actually- Searching reminded me."
    b "When I visited your father's residence some time ago, my birds picked up a journal that belonged to Zuru's late father."

    show zuru sad at centerright
    s "My father's journals?"
    b "The piece has been " # something something - at the birdnest ????? they pick up the piece of evidence and FIND THE KILLER LETS GOOOOOOOOOOOOOOO
    
    scene black
    with fade

    centered "GOOD END REACHED: Kiss Kiss Fall In Love"
    $ persistent.lastending = "6"
    $ persistent.haremendreached = True

    scene black
    with fade

    centered "GOOD END REACHED: In a Mouse's Nature"
    $ persistent.lastending = "6"
    $ persistent.pairendreached = True

    return