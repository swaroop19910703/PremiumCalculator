async function calculatePremium() {
    const name = document.getElementById('name').value;
    const age = parseInt(document.getElementById('age').value || '0');
    const dob = document.getElementById('dob').value;
    const occupation = document.getElementById('occupation').value;
    const sum = parseFloat(document.getElementById('sum').value || '0');

    if (!name || !age || !dob || !occupation || !sum) {
        return;
    }

    const payload = { name, age, dateOfBirth: dob, occupation, deathSumInsured: sum };

    try {
        const res = await fetch('/api/premium/calculate', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (!res.ok) {
            const err = await res.json();
            alert(err?.error || 'Error calculating premium');
            return;
        }

        const data = await res.json();
        document.getElementById('premium').innerText = data.monthlyPremium;
    } catch (e) {
        console.error(e);
        alert('Unable to calculate premium right now.');
    }
}

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('occupation').addEventListener('change', calculatePremium);
    document.getElementById('sum').addEventListener('input', calculatePremium);
    document.getElementById('age').addEventListener('input', calculatePremium);
    document.getElementById('name').addEventListener('input', calculatePremium);
    document.getElementById('dob').addEventListener('input', calculatePremium);
});
