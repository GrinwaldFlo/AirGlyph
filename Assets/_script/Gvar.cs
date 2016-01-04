using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

internal static class Gvar
{
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
accept / human / weak
advance / civilization / pursue / shapers / path
advance / civilization / pursue / shapers / truth
advance / civilization / repeat / failure
advance / enlightenment
advance / future / not / war
advance / human / enlightenment
advance / human / resistance
advance / pure / truth
again / journey / outside
all / chaos / inside / body
all / civilization / chaos
all / xm / liberate
answer / question / discover / difficult / truth
answer / repeat / struggle
attack / civilization / repeat / failure
attack / create / danger
attack / destroy / future
attack / difficult / future
attack / enlightenment / pursue / resistance
attack / future / change / destiny
attack / human / civilization / xm / message
attack / pure / future / human / civilization
attack / pure / future / inside / war
attack / resistance / pursue / enlightenment
attack / separate / path / end / journey
attack / shapers / chaos
attack / shapers / evolution
attack / shapers / portal
attack / weak / shapers / lie
avoid / attack / chaos
avoid / chaos / avoid / shapers / lie
avoid / chaos / repair / potential / war
avoid / chaos / soul
avoid / complex / conflict
avoid / complex / soul
avoid / conflict
avoid / destiny / lie
avoid / impure / evolution
avoid / perfection / stability / human / self
avoid / pure / chaos
avoid / war / chaos
avoid / xm / message / lie
breathe / again / journey / again
breathe / inside / xm / lose / self
breathe / nature / perfection / harmony
capture / fear / discover / courage
capture / portal / defend / portal / courage
capture / shapers / portal
capture / xm / portal
change / body / improve / human
change / future / capture / destiny
change / human / future
change / human / potential / use
change / present
change / separate / past / end / journey
change / simple / human / future
chaos / attack / conflict / discover / harmony
chaos / barrier / shapers / portal
chaos / destroy / shapers / portal
chaos / perfection / stability / human / self
chaos / war / conflict / discover / peace
civilization / war / chaos
clear / mind / liberate / barrier / body
clear / mind / open / mind
clear all / idea / past / present / future
clear all / mind / liberate / barrier / body
clear all / open / mind / begin
clear all / open all / discover / truth
clear all / open all / gain / truth
clear all / thought / past / present / future
complex / journey / future
complex / shapers / civilization / strong
contemplate / complex / shapers / civilization
contemplate / complex / shapers / truth
contemplate / future / not / shapers / path
contemplate / journey / outside
contemplate / potential / balance
contemplate / potential / journey
contemplate / potential / perfection
contemplate / restraint / discover / more / courage
contemplate / self / path / truth
courage / attack / shapers / future
courage / attack / shapers / portal / together
courage / destiny / rebel
courage / destroy / shapers / portal / together
courage / war / shapers / future
create / distance / impure / path
create / future / change / destiny
create / future / inside / war
create / future / journey
create / future / not / war
create / outside / impure / path
create / pure / future / human / civilization
create / pure / future / not / war
create / separate / path / end / journey
danger / change / past
defend / destiny / defend / human / civilization
defend / human / civilization / portal / message
defend / human / civilization / shapers / lie
defend / human / civilization / shapers / portal
defend / human / civilization / xm / message
defend / message / answer / idea
defend / seek / safety
destroy / civilization / danger
destroy / civilization / now / conflict / war
destroy / complex / shapers / lie
destroy / destiny / barrier
destroy / destiny / human / lie
destroy / difficult / barrier
destroy / impure / truth
destroy / lie / inside / gain / soul
destroy / weak / civilization
deteriorate / advance / present
deteriorate / human / weak / rebel
discover / harmony / equal
discover / perfection / safety / all
discover / portal / truth
discover / portal
discover / pure / truth
discover / resistance / truth
discover / safety / civilization
discover / shapers / civilization
discover / shapers / enlightenment
discover / shapers / lie
discover / shapers / message
distance / self / avoid / human / lie
distance / you / mind / more
easy / past / future / follow / shapers
end / journey / discover / destiny
escape / body / journey / distance / present
escape / body / journey / outside / now
escape / evolution
escape / impure / evolution
escape / impure / future
escape / impure / truth
escape / portal / harm
escape / shapers / harm
escape / shapers / harmony
escape / simple / human / future
escape / together
fear / chaos / xm
fear / complex / xm
follow / journey
follow / pure / journey
follow / shapers / portal / message
forget / attack / see / outside / harmony
forget / conflict / accept / war
forget / past / see / present / danger
forget / war / gain / outside / harmony
future / equal / past
gain / civilization / peace
gain / future / escape
gain / portal / attack / weak
gain / safety
gain / truth / open / human / soul
harm / danger / avoid
harm / progress / pursue / more / war
harmony / path / nourish / present
harmony / stability / future
help / enlightenment / capture / all / portal
help / gain / create / pursue
help / human / civilization / pursue / destiny
help / resistance / capture / all / portal
help / shapers / create / future
hide / impure / human / thought
hide / journey / truth
hide / path / future
hide / resistance / advance / strong / together
hide / truth
human / gain / safety
human / have / impure / civilization
human / not / together / civilization / deteriorate
human / past / present / future
human / shapers / together / create / destiny
human / soul / strong / pure
ignore / human / chaos / lie
imperfect / truth / open / complex / answer
imperfect / xm / message / human / chaos
improve / advance / present
improve / body / mind / soul
improve / body / pursue / journey
improve / future / together
improve / human / shapers
improve / mind / body / inside
improve / mind / improve / courage / change
improve / mind / journey / inside
inside / mind / future
inside / mind / inside / soul / harmony
inside / mind / journey / perfection
inside / mind / soul / harmony
inside / xm / truth
journey / inside / improve / soul
journey / inside / soul
lead / body / mind / soul
lead / enlightenment / civilization
lead / pursue / react / defend
lead / resistance / question
less / chaos / more / stability
less / mind / more / soul
less / soul / more / mind
less / truth / more / chaos
liberate / human / future
liberate / portal / liberate / human / mind
liberate / portal / potential
liberate / self / liberate / human / civilization
liberate / xm / portal / together
live / again / journey / again
live / inside / xm / lose / self
live / nature / balance / harmony
live / nature / perfection / harmony
lose / attack / retreat
lose / danger / gain / safety
lose / shapers / message / gain / chaos
lose / war / retreat
mind / body / live
mind / body / soul / pure / human
mind / equal / truth
mind / open / live
more / data / gain / portal / advance
more / mind / less / spirit
nature / pure / defend
not / mind / journey / perfection
nourish / journey
nourish / mind / journey
nourish / xm / create / thought
nourish / xm / portal
old / nature / less / strong / now
open / chaos / inside / body
open / human / weak
open all / clear all / discover / truth
open all / portal / success
open all / portal
open all / simple / truth
past / again / present / again
past / barrier / create / future / journey
past / chaos / create / future / harmony
past / equal / future
past / harmony / difficult
past / path / create / future / journey
past / peace / difficult
past / present / future
path / harmony / difficult
path / peace / difficult
path / peace
path / perfection
path / restraint / strong / safety
peace / path / nourish / future
peace / path / nourish / present
peace / simple / journey
peace / stability / future
perfection / balance / safety / all
perfection / past / peace
portal / attack / danger / pursue / safety
portal / barrier / defend / human / shapers
portal / change / civilization / end
portal / create / danger / pursue / safety
portal / die / civilization / die
portal / have / truth / data
portal / improve / human / future / civilization
portal / potential / change / future
portal / potential / help / human / future
potential / truth / harmony
potential / xm / attack
potential / xm / harmony
potential / xm / peace
potential / xm / war
present / chaos / create / future / civilization
present / mind / journey / perfection
pure / truth
pursue / complex / truth
pursue / conflict / advance / war / chaos
pursue / conflict / attack / advance / chaos
pursue / path / outside / shapers / lie
pursue / pure / body
question / all
question / conflict / data
question / hide / truth
question / human / civilization / destroy / portal
question / human / truth
question / less / forget / all / lie
question / shapers / chaos
question / truth / gain / future
question / truth
question / war
question / you / impure / civilization
react / impure / civilization
react / pure / truth
react / rebel / question / shapers / lie
rebel / idea / evolution / destiny / harmony
rebel / idea / success / destiny / now
rebel / thought / evolution / destiny / now
repair / inside / repair / human / soul
repair / nature / balance
repair / present / repair / human / soul
repair / soul / less / human / harm
repeat / journey / outside
resistance / defend / shapers / danger
restraint / fear / avoid / danger
restraint / path / gain / harmony
retreat / seek / safety
save / human / civilization / destroy / portal
save / human / potential / use
search / data / discover / path
search / destiny / create / pure / future
search / truth / save / civilization
search / xm / portal
search / xm / save / portal
see / truth / now
see / truth / see / future
seek / data / discover / path
seek / destiny / create / pure / future
seek / message / discover / path
seek / potential
seek / signal / discover / path
seek / truth / see / future
seek / xm / portal
seek / xm / save / portal
separate / future / evolution
separate / future / pursue
separate / mind / body / discover / enlightenment
separate / truth / lie / shapers / future
separate / weak / ignore / truth
shapers / avoid / pure / thought
shapers / chaos / pure / harm
shapers / gain / potential / evolution
shapers / have / strong / path
shapers / lead / human / complex / journey
shapers / lose / potential / evolution
shapers / message / end / civilization
shapers / mind / complex / harmony
shapers / past / present / future
shapers / past / present / future
shapers / portal / message / create / chaos
shapers / portal / message / destroy / civilization
shapers / portal / mind / restraint
shapers / see / complex / path / destiny
shapers / see / potential / evolution
shapers / want / human / mind / future
simple / civilization / impure / weak
simple / message / complex / idea
simple / old / truth / journey / inside
simple / truth / breathe / nature
simple / truth / forget / easy / success
simple / truth / live / nature
simple / truth / shapers / destroy / civilization
soul / rebel / human / die
stability / pure / live / knowledge
stay / strong / together / defend / resistance
stay / together / defend / truth
strong / idea / pursue / truth
strong / mind
strong / resistance / capture / portal
strong / soul
strong / together / attack / together / destiny
strong / together / avoid / war
strong / together / war / together / destiny
struggle / defend / shapers / danger
struggle / improve / human / soul
together / discover / harmony / equal
together / pure / journey
together / pursue / safety
truth / idea / discover / xm
truth / nourish / soul
use / mind / use / courage / change
use / restraint / follow / easy / path
use / us / create / shapers / knowledge
use / us / follow / us
want / truth / now
want / truth / pursue / difficult / path
want / xm / now
war / attack / chaos
war / create / danger
war / destroy / future
weak / human / destiny / destroy / civilization
xm / create / complex / human / destiny
xm / die / chaos / live
xm / have / mind / harmony
xm / have / mind / journey
xm / nourish / civilization
xm / past / future / destiny / harmony
xm / path / future / journey / harmony
you / destiny / not / easy
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
}

internal class clPhrase
{
	internal clGlyph[] phrase;
	internal bool loadOK;

	internal clPhrase(string fullPhrase)
	{
		loadOK = false;
		string[] names = fullPhrase.Split(new string[] { " / " }, StringSplitOptions.RemoveEmptyEntries);

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