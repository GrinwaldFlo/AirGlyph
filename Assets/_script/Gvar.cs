using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

internal static class Gvar
{
	internal const string glyphNext = "More";
	internal const string glyphEnd = "End";

	internal const int nbPlayerMax = 8;

	internal static enGameState gameState { get; private set; }
	internal static enGame game;


	internal static void setGameState(enGameState state)
	{
		gameState = state;
	}

	internal static List<clGlyph> lstGlyph = new List<clGlyph>();
	internal static Dictionary<string, clGlyph> dicGlyph = new Dictionary<string, clGlyph>();
	internal static List<clPhrase> lstPhrase = new List<clPhrase>();

	internal static void generateGlyph()
	{
		Gvar.lstGlyph = new List<clGlyph>();
		Gvar.lstGlyph.Add(new clGlyph("Abandon", new int[] { 304, 308, 610, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Adapt", new int[] { 208, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Advance", new int[] { 107, 307 }));
		Gvar.lstGlyph.Add(new clGlyph("After", new int[] { 506, 509, 610, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Again / Repeat", new int[] { 307, 708, 811, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("All", new int[] { 102, 106, 203, 304, 405, 506 }));
		Gvar.lstGlyph.Add(new clGlyph("Answer", new int[] { 710, 910, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Attack / War", new int[] { 107, 110, 307, 510 }));
		Gvar.lstGlyph.Add(new clGlyph("Avoid", new int[] { 102, 110, 609, 610 }));
		Gvar.lstGlyph.Add(new clGlyph("Barrier / Obstacle", new int[] { 111, 509, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Before", new int[] { 203, 207, 308, 711, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Begin", new int[] { 108, 408, 409 }));
		Gvar.lstGlyph.Add(new clGlyph("Being / Human", new int[] { 408, 409, 708, 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Body / Shell", new int[] { 710, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Breathe / Live", new int[] { 207, 610, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Capture", new int[] { 304, 308, 609, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Change / Modify", new int[] { 409, 411, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Chaos / Disorder", new int[] { 102, 106, 203, 408, 610, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Clear", new int[] { 111, 411 }));
		Gvar.lstGlyph.Add(new clGlyph("Clear All", new int[] { 102, 106, 111, 203, 304, 405, 411, 506 }));
		Gvar.lstGlyph.Add(new clGlyph("Complex", new int[] { 710, 711, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Conflict", new int[] { 307, 510, 708, 809, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Consequence", new int[] { 207, 509, 708, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Contemplate", new int[] { 106, 405, 408, 506, 708, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Contract / Reduce", new int[] { 510, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Courage", new int[] { 307, 708, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Create / Creation", new int[] { 308, 610, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Creativity", new int[] { 407, 411, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("Thought / Idea", new int[] { 203, 207, 308, 506, 509, 610, 711, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Danger", new int[] { 107, 411, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("Data / Signal", new int[] { 110, 408, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Defend", new int[] { 208, 408, 409, 609 }));
		Gvar.lstGlyph.Add(new clGlyph("Destination", new int[] { 405, 506 }));
		Gvar.lstGlyph.Add(new clGlyph("Destiny", new int[] { 408, 711, 809, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Destroy / Destruction", new int[] { 207, 509, 711, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Deteriorate / Erode", new int[] { 308, 711, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Die", new int[] { 308, 509, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Difficult", new int[] { 610, 811, 910, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Discover", new int[] { 304, 405, 506 }));
		Gvar.lstGlyph.Add(new clGlyph("Distance / Outside", new int[] { 102, 203 }));
		Gvar.lstGlyph.Add(new clGlyph("Easy", new int[] { 408, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("End / Close / Finality", new int[] { 106, 111, 409, 411, 609 }));
		Gvar.lstGlyph.Add(new clGlyph("Enlightened / Enlightenment", new int[] { 106, 107, 405, 506, 710, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Equal", new int[] { 708, 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Escape", new int[] { 106, 610, 708, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Evolution / Success / Progress", new int[] { 111, 708, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("Failure", new int[] { 111, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Fear", new int[] { 609, 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Follow", new int[] { 110, 506, 610 }));
		Gvar.lstGlyph.Add(new clGlyph("Forget", new int[] { 308 }));
		Gvar.lstGlyph.Add(new clGlyph("Future / Forward-Time", new int[] { 509, 610, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Gain", new int[] { 208 }));
		Gvar.lstGlyph.Add(new clGlyph("Government / City / Civilization / Structure", new int[] { 207, 610, 708, 809, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Grow", new int[] { 307, 708 }));
		Gvar.lstGlyph.Add(new clGlyph("Harm", new int[] { 107, 110, 509, 711, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Harmony / Peace", new int[] { 107, 110, 408, 409, 711, 811, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Have", new int[] { 408, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Help", new int[] { 207, 711, 809, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Hide", new int[] { 609, 610, 710, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("I / Me", new int[] { 407, 410, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Ignore", new int[] { 509 }));
		Gvar.lstGlyph.Add(new clGlyph("Imperfect", new int[] { 708, 711, 810, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Improve", new int[] { 610, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Impure", new int[] { 411, 708, 711, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Intelligence", new int[] { 308, 610, 708, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Interrupt", new int[] { 111, 203, 207, 308, 411, 711, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Journey", new int[] { 203, 207, 304, 610, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Knowledge", new int[] { 407, 410, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Lead", new int[] { 102, 203, 308, 408 }));
		Gvar.lstGlyph.Add(new clGlyph("Legacy", new int[] { 102, 106, 207, 308, 509, 610, 708, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Less", new int[] { 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Liberate", new int[] { 106, 307, 610, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Lie", new int[] { 708, 711, 910, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Live Again / Reincarnate", new int[] { 307, 610, 708, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Lose / Loss", new int[] { 609 }));
		Gvar.lstGlyph.Add(new clGlyph("Message", new int[] { 307, 609, 711, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Mind", new int[] { 408, 411, 708, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("More", new int[] { 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Mystery", new int[] { 107, 110, 207, 708, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("N'zeer", new int[] { 107, 110, 111, 411, 711, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Nature", new int[] { 308, 509, 708, 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("New", new int[] { 509, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("No / Not / Absent / Inside", new int[] { 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Nourish", new int[] { 304, 308, 411, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Old", new int[] { 207, 708 }));
		Gvar.lstGlyph.Add(new clGlyph("Open / Accept", new int[] { 408, 409, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Open All", new int[] { 102, 106, 203, 304, 405, 408, 409, 506, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Opening / Doorway / Portal", new int[] { 203, 207, 308, 506, 509, 610, 710, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Past", new int[] { 207, 308, 708 }));
		Gvar.lstGlyph.Add(new clGlyph("Path", new int[] { 111, 308, 811 }));
		Gvar.lstGlyph.Add(new clGlyph("Perfection / Balance", new int[] { 111, 304, 308, 405, 509, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Perspective", new int[] { 107, 110, 308, 509, 711, 811, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Potential", new int[] { 111, 506, 509, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Presence", new int[] { 408, 409, 708, 711, 809, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Present / Now", new int[] { 708, 809, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Pure / Purity", new int[] { 111, 910, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Pursue / Aspiration", new int[] { 107, 110, 207 }));
		Gvar.lstGlyph.Add(new clGlyph("Chase", new int[] { 111, 308, 708, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("Question", new int[] { 110, 708, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("React", new int[] { 509, 710, 711, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Rebel", new int[] { 208, 506, 610, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Recharge / Repair", new int[] { 102, 111, 207, 711 }));
		Gvar.lstGlyph.Add(new clGlyph("ResistB / ResistanceB", new int[] { 107, 111, 409, 411, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Resist / Resistance / Struggle", new int[] { 107, 111, 408, 411, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Restraint", new int[] { 207, 405, 509, 711, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Retreat", new int[] { 110, 510 }));
		Gvar.lstGlyph.Add(new clGlyph("Safety", new int[] { 307, 510, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Save / Rescue", new int[] { 609, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("See", new int[] { 107 }));
		Gvar.lstGlyph.Add(new clGlyph("Seek / Search", new int[] { 708, 710, 809, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Self", new int[] { 304, 405 }));
		Gvar.lstGlyph.Add(new clGlyph("Separate", new int[] { 207, 509, 708, 811, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Shapers / Collective", new int[] { 107, 110, 308, 509, 708, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Share", new int[] { 304, 308, 509, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Simple", new int[] { 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Soul / Spirit / Life Force", new int[] { 409, 411, 910, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Stability / Stay", new int[] { 308, 509, 809 }));
		Gvar.lstGlyph.Add(new clGlyph("Strong", new int[] { 708, 710, 809, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Sustain", new int[] { 111, 411, 506, 509, 610, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Sustain all", new int[] { 102, 106, 111, 203, 304, 405, 411, 506, 509, 610, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Technology", new int[] { 509, 610, 708, 711, 811, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Together", new int[] { 308, 710, 711, 811, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Truth", new int[] { 708, 711, 811, 910, 911, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Unbounded", new int[] { 102, 106, 203, 304, 405, 609, 708, 710, 809, 1011 }));
		Gvar.lstGlyph.Add(new clGlyph("Use", new int[] { 609, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("Victory", new int[] { 107, 110, 407, 410 }));
		Gvar.lstGlyph.Add(new clGlyph("Want / Desire", new int[] { 308, 408, 409 }));
		Gvar.lstGlyph.Add(new clGlyph("We / Us", new int[] { 410, 710 }));
		Gvar.lstGlyph.Add(new clGlyph("Weak", new int[] { 207, 710, 910 }));
		Gvar.lstGlyph.Add(new clGlyph("Worth", new int[] { 208, 609, 811, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("XM", new int[] { 708, 710, 811, 910, 911 }));
		Gvar.lstGlyph.Add(new clGlyph("You / Other", new int[] { 108, 109, 809 }));

		dicGlyph = new Dictionary<string, clGlyph>();
		for (int i = 0; i < lstGlyph.Count; i++)
		{
			for (int j = 0; j < lstGlyph[i].names.Length; j++)
			{
				if (dicGlyph.ContainsKey(lstGlyph[i].names[j]))
					Debug.Log("Key exists: " + lstGlyph[i].names[j]);
				else
					dicGlyph.Add(lstGlyph[i].names[j].ToLower(), lstGlyph[i]);
			}
		}



		string phrasebook = @"
accept/human/weak
advance/civilization/pursue/shapers/path
advance/civilization/repeat/failure
advance/human/resistance
advance/pure/truth
again/journey/outside
all/chaos/inside/body
all/civilization/chaos
all/xm/liberate
answer/question/discover/difficult/truth
answer/repeat/struggle
attack/difficult/future
attack/enlightenment/pursue/resistance
attack/resistance/pursue/enlightenment
attack/shapers/chaos
attack/shapers/evolution
attack/weak/shapers/lie
avoid/chaos/avoid/shapers/lie
avoid/chaos/repair/potential/war
avoid/complex/conflict
avoid/destiny/lie
avoid/perfection/stay/human/self
avoid/war/chaos
avoid/xm/message/lie
breathe/again/journey/again
breathe/inside//lose/self
breathe/nature/perfection/harmony
capture/fear/discover/courage
capture/portal/defend/portal/courage
capture/shapers/portal
change/body/improve/human
change/future/capture/destiny
change/human/future
change/human/potential/use
chaos/barrier/shapers/portal
chaos/war/conflict/discover/peace
civilization/die/new/civilization/begin
civilization/war/chaos
clear/mind/liberate/barrier/body
clear/mind/open/mind
clear all/open all/discover/truth
clear all/thought/past/present/future
complex/journey/future
complex/shapers/civilization/strong
contemplate/complex/shapers/civilization
contemplate/complex/shapers/truth
contemplate/future/not/shapers/path
contemplate/journey/outside
contemplate/potential/perfection
contemplate/restraint/discover/more/courage
contemplate/self/path/truth
courage/attack/shapers/portal/together
courage/destiny/future
courage/destiny/rebel
courage/war/shapers/future
create/distance/impure/path
create/future/change/destiny
create/future/journey
create/future/not/war
create/new/future
create/new/future/see/all
create/pure/future/human/civilization
create/pure/future/not/war
create/separate/path/end/journey
danger/change/past
defend/destiny/defend/human/civilization
defend/human/civilization/portal/data
defend/human/civilization/shapers/lie
defend/human/civilization/shapers/portal
defend/human/civilization/xm/message
defend/message/answer/idea
destroy/civilization/danger
destroy/civilization/end/conflict/war
destroy/complex/shapers/lie
destroy/destiny/barrier
destroy/destiny/human/lie
destroy/difficult/barrier
destroy/impure/truth
destroy/lie/inside/gain/soul
destroy/weak/civilization
deteriorate/human/weak/rebel
discover/portal/truth
discover/pure/truth
discover/resistance/truth
discover/safety/civilization
discover/shapers/enlightenment
discover/shapers/lie
discover/shapers/message
distance/self/avoid/human/lie
easy/path/future/follow/shapers
end/journey/discover/destiny
end/old/civilization/create/new
escape/body/journey/outside/present
escape/body/mind/self/want
escape/impure/evolution
escape/impure/future
escape/impure/truth
escape/shapers/harm
escape/simple/human/future
fear/chaos/xm
follow/pure/journey
follow/shapers/portal/message
forget/conflict/accept/war
forget/past/see/present/danger
forget/war/see/distance/harmony
future/equal/past
gain/civilization/peace
gain/portal/attack/weak
gain/truth/open/human/soul
grow/unbounded/create/new/future
harm/danger/avoid
harm/progress/pursue/more/war
harmony/path/nourish/present
help/enlightenment/capture/all/portal
help/gain/create/pursue
help/human/civilization/pursue/destiny
help/resistance/capture/all/portal
help/shapers/create/future
hide/impure/human/thought
hide/journey/truth
hide/path/future
hide/struggle/advance/strong/together
human/escape/all
human/evolution/unbounded
human/failure/unbounded
human/gain/safety
human/have/impure/civilization
human/intelligence/unbounded
human/not/together/civilization/deteriorate
human/past/present/future
human/shapers/together/create/destiny
human/soul/strong/pure
ignore/human/chaos/lie
imperfect/truth/accept/complex/answer
imperfect/xm/message/human/chaos
improve/advance/present
improve/body/mind/soul
improve/body/pursue/journey
improve/human/shapers
improve/mind/journey/inside
inside/mind/future
inside/mind/inside/soul/harmony
inside/mind/journey/perfection
inside/xm/truth
journey/inside/improve/soul
journey/inside/soul
lead/enlightenment/civilization
lead/pursue/react/defend
lead/resistance/question
less/chaos/more/stability
less/soul/more/mind
less/truth/more/chaos
liberate/portal/liberate/human/mind
liberate/portal/potential
liberate/self/liberate/human/civilization
liberate/xm/portal/together
lose/attack/retreat
lose/danger/gain/safety
lose/shapers/message/gain/chaos
mind/body/soul/pure/human
mind/equal/truth
mind/open/live
more/data/gain/portal/advance
nature/pure/defend
nourish/mind/journey
nourish/xm/create/thought
old/nature/less/strong/now
open all/portal/success
open all/simple/truth
past/again/present/again
past/chaos/create/future/harmony
past/equal/future
past/path/create/future/journey
past/present/future
path/peace/difficult
path/restraint/strong/safety
peace/path/nourish/present
peace/simple/journey
perfection/balance/safety/all
perfection/path/peace
portal/barrier/defend/human/shapers
portal/change/civilization/end
portal/create/danger/pursue/safety
portal/die/civilization/die
portal/have/truth/data
portal/improve/human/future/civilization
portal/potential/change/future
portal/potential/help/human/future
potential/xm/war
present/chaos/create/future/civilization
pure/human/failure/now/chaos
pursue/complex/truth
pursue/conflict/war/advance/chaos
pursue/path/outside/shapers/lie
pursue/pure/body
question/conflict/data
question/hide/truth
question/less/forget/all/lie
question/shapers/chaos
question/truth/gain/future
react/impure/civilization
react/rebel/question/shapers/lie
rebel/thought/evolution/destiny/now
recharge/present/recharge/human/soul
repair/nature/balance
repair/soul/less/human/harm
restraint/fear/avoid/danger
restraint/path/gain/harmony
retreat/search/safety
save/human/civilization/destroy/portal
search/data/discover/path
search/destiny/create/pure/future
search/truth/save/civilization
search/xm/portal
search/xm/save/portal
see/truth/now
see/truth/see/future
separate/future/evolution
separate/mind/body/discover/enlightenment
separate/truth/lie/shapers/future
separate/weak/ignore/truth
shapers/chaos/pure/harm
shapers/have/strong/path
shapers/lead/human/complex/journey
shapers/message/end/civilization
shapers/mind/complex/harmony
shapers/past/present/future
shapers/portal/data/create/chaos
shapers/portal/message/destroy/civilization
shapers/portal/mind/restraint
shapers/see/complex/path/destiny
shapers/see/potential/evolution
shapers/want/human/mind/future
simple/civilization/impure/weak
simple/message/complex/idea
simple/old/truth/journey/inside
simple/truth/breathe/nature
simple/truth/forget/easy/success
simple/truth/shapers/destroy/civilization
soul/rebel/human/die
stay/strong/together/defend/resistance
stay/together/defend/truth
strong/idea/pursue/truth
strong/resistance/capture/portal
strong/together/attack/together/chaos
strong/together/attack/together/destiny
strong/together/avoid/war
struggle/defend/shapers/danger
struggle/improve/human/soul
technology/intelligence/grow/unbounded
technology/intelligence/see/all
technology/intelligence/see/all/unbounded
together/discover/harmony/equal
together/pursue/safety
truth/idea/discover/xm
truth/nourish/soul
use/mind/use/courage/change
use/restraint/follow/easy/path
want/truth/now
want/truth/pursue/difficult/path
war/create/danger
war/destroy/future
weak/human/destiny/destroy/civilization
xm/create/complex/human/destiny
xm/die/chaos/live
xm/have/mind/journey
xm/nourish/civilization
xm/path/future/destiny/harmony
";

		lstPhrase = new List<clPhrase>();
		string[] phrases = phrasebook.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < phrases.Length; i++)
		{
			clPhrase newPhrase = new clPhrase(phrases[i]);
			if (newPhrase.loadOK)
				lstPhrase.Add(newPhrase);
		}
	}
}

internal static class Cmd
{
	internal const string Inactive = "#Inactive";
	internal const string Active = "#Active";
}

internal static class Lng
{
	internal const string YourTurn = "Your turn";
	internal const string Wait = "Wait";
	internal const string Intro = "Choose your game by glyphing";
	internal const string End = "Glyph \"" + Gvar.glyphNext + "\" to go to intro";
	internal const string TellFirstHelp = "Glyph only glyphs that have not yet been glyphed";
	internal const string FindSequenceHelp = "Glyph existing sequences. If you think the sequence is complete, glyph \"" + Gvar.glyphEnd + "\"\r\n3 glyphs minimum";
	internal const string Win = "{0} wins with {1} points";
	internal const string Lose = "No winner, shame on you !";
	internal const string NotYourTurn = "It's not your turn";
	internal const string NotAGlyph = "???";
	internal const string GlyphMissed = "Glyph missed\r\n{0} remaining tries";
	internal const string GlyphOK = "Good !";
	internal const string GlyphRemaining = "{0} glyphs remaining";
	internal const string AlreadyWritten = "Already written !\r\n{0} remaining tries";
	internal const string GlyphMissedList = "Here are the glyphs you missed";
	internal const string Skip = "Glyph \"" + Gvar.glyphNext + "\" to skip";
	internal const string NotASequence = "This is not a valid sequence or it's already been found !\r\n{0} remaining tries";
	internal const string SequenceOK = "Good sequence!\r\nLet's start a new one";
	internal const string SequenceRemaining = "{0} sequences remaining";
	internal const string SequenceGlyphOK = "Good!\r\nGlyph the rest of the sequence";
	internal const string SequenceLose = "You lost, here is an existing sentence";
	internal const string SequenceStartWith = "{0} sequences start with these glyphs";
}

internal class clGlyph
{
	internal string name;
	internal string[] names;
	internal int[] pattern;

	internal clGlyph(string name, int[] pattern)
	{
		this.name = name;
		this.pattern = pattern;
		this.names = name.Split(new string[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
	}

	internal bool hasName(string singleName)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i] == singleName)
				return true;
		}
		return false;
	}
}

internal class clPhrase
{
	internal clGlyph[] phrase;
	internal bool loadOK;

	internal clPhrase(string fullPhrase)
	{
		loadOK = false;
		string[] names = fullPhrase.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

		if (names.Length == 0)
			return;

		phrase = new clGlyph[names.Length];
		for (int i = 0; i < names.Length; i++)
		{
			clGlyph curGlyph;
			if (!Gvar.dicGlyph.TryGetValue(names[i], out curGlyph))
			{
				Debug.Log("Phrase word not found " + names[i]);
				return;
			}
			else
			{
				phrase[i] = curGlyph;
			}

		}
		loadOK = true;
	}

	public bool contains(clGlyph[] lst)
	{
		if (lst == null)
			return false;

		if (lst.Length > phrase.Length)
			return false;

		for (int i = 0; i < lst.Length; i++)
		{
			if (lst[i].name != phrase[i].name)
				return false;
		}

		return true;
	}

	public bool Equals(clGlyph[] lst)
	{
		if (lst == null)
			return false;

		if (lst.Length != phrase.Length)
			return false;

		for (int i = 0; i < lst.Length; i++)
		{
			if (lst[i].name != phrase[i].name)
				return false;
		}

		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}


internal enum enGameState
{
	None,
	Intro,
	Ready,
	Play,
	End
}

internal enum enGame
{
	None,
	FindSentence,
	TellFirst
}

class clSegment : IComparable<clSegment>
{
	internal int id1;
	internal int id2;
	internal int id;

	internal clSegment(int Id1, int Id2)
	{
		if (Id1 < Id2)
		{
			id1 = Id1;
			id2 = Id2;
		}
		else
		{
			id1 = Id2;
			id2 = Id1;
		}

		id = id1 * 100 + id2;
	}

	public int CompareTo(clSegment other)
	{
		return id.CompareTo(other.id);
	}
}

enum msgResponse
{
	None,
	NotYourTurn,
	BadGlyph,
	GoodGlyph
}